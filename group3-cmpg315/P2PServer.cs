using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace P2PServer
{
    public class PeerToPeerServer
    {
        // Declare a private TcpListener object to listen for incoming connections
        private TcpListener listener;

        // Declare a private array of TcpClient objects to store connected clients
        private TcpClient[] clients;

        // Declare a private integer to keep track of the number of connected clients
        private int clientNum;

        // Declare a private boolean to indicate whether the server is running
        private bool Running;

        // Define a constructor for our PeerToPeerServer class
        public PeerToPeerServer()
        {
            // Initialize the array of TcpClient objects with a size of 100
            clients = new TcpClient[100];

            // Initialize the clientNum variable to 0, indicating no clients are connected
            clientNum = 0;

            // Set the Running variable to true, indicating the server is running
            Running = true;
        }

        public void Start(int port)
        {
            try
            {
          
                // Set up the server socket
                // Create an IPAddress object to represent the IP address the server will listen on
                // IPAddress.Any represents the IP address 0.0.0.0, which means the server will listen on all available network interfaces
                IPAddress ipAddress = IPAddress.Any;

                // Create a new TcpListener object to listen for incoming connections
                // The TcpListener constructor takes two parameters: the IP address to listen on and the port number to listen on
                listener = new TcpListener(ipAddress, port);

                // Start listening for incoming connections
                // The Start method begins listening for incoming connections
                // The server is now ready to accept incoming connections
                listener.Start();

                // Print a message to the console indicating the server has started
                // The message includes the IP address and port number the server is listening on
                Console.WriteLine("Server started on port {0}, {1}", ipAddress, port);


                while (Running)// Continuously run the server loop as long as the Running flag is true
                {
                    
                    // Accept a new client connection
                    // The AcceptTcpClient method blocks until an incoming connection is received
                    // A new TcpClient object is created to represent the connected client
                    TcpClient client = listener.AcceptTcpClient();

                    // Print a message to the console indicating a new client has connected
                    // The message includes the remote endpoint (IP address and port) of the client
                    Console.WriteLine("Client connected to the PTP server: {0}", client.Client.RemoteEndPoint);

                    // Add the client to the array
                    // Use a lock to ensure thread safety when accessing the clients array
                    lock (clients)
                    {
                        // Add the new client to the next available slot in the array
                        clients[clientNum] = client;

                        // Increment the clientNum variable to keep track of the number of connected clients
                        clientNum++;
                    }

                    // Create a new thread to handle communication with the client
                    // The ParameterizedThreadStart delegate allows passing a parameter to the new thread
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient));

                    // Start the new thread, passing the connected client as a parameter
                    clientThread.Start(client);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Stop()// This method is used to stop the server
        {        
            try
            {
                // Set the Running flag to false to exit the server loop
                Running = false;

                // Stop the TcpListener from accepting new connections
                // This will also disconnect any pending connections
                listener.Stop();

                // Print a message to the console indicating the server has stopped
                Console.WriteLine("Server stopped");
            }
            catch (Exception ex)
            {
                // If an error occurs during the shutdown process, catch the exception
                // Print the error message to the console
                Console.WriteLine(ex.Message);
            }
        }

        private void HandleClient(object obj)
        {
            // Cast the object to a TcpClient, which represents a connected client
            TcpClient client = obj as TcpClient;

            // Get the network stream associated with the connected client
            NetworkStream stream = client.GetStream();

            // Declare an empty string variable (not used in this snippet)
            string clientId = "";

            // Create a byte array containing the ASCII-encoded string
            // The string includes the client's IP address and port, using string interpolation
            byte[] data = Encoding.ASCII.GetBytes($"Your IP#{client.Client.RemoteEndPoint}");

            // Write the byte array to the network stream
            // The Write method takes three parameters: the byte array, the offset (0 in this case), and the length of the data
            stream.Write(data, 0, data.Length);

            try
            {
                // Continuously run the server loop as long as the Running flag is true
                while (Running)
                {
                    // Receive the client's identifier (IP address and port)
                    clientId = client.Client.RemoteEndPoint.ToString();

                    // Receive a message from the client
                    // Create a buffer to hold the received data
                    byte[] buffer = new byte[1024];
                    // Read data from the network stream into the buffer
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    // Convert the received data to a string
                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                    // If no data was received, break out of the loop
                    if (bytesRead == 0)
                        break;

                    // Extract the recipient and message content from the received message
                    // Split the message into parts using the ':' character as a separator
                    string[] parts = message.Split(new[] { ':' }, 3);
                    // Get the recipient's identifier (IP address and port)
                    string recipientId = parts[0] + ":" + parts[1];
                    // Get the message content
                    string content = parts[2];

                    // Find the recipient client in the array of connected clients
                    TcpClient recipient = Array.Find(clients, c => GetClientId(c) == recipientId);

                    // If the recipient client is found and connected
                    if (recipient != null && recipient.Connected)
                    {
                        // Try to send the message to the recipient
                        bool messageSent = SendMessage(recipientId, content, clientId);

                        // If the message was not sent successfully
                        if (!messageSent)
                        {
                            // Send a response back to the sender indicating failure
                            byte[] response = Encoding.ASCII.GetBytes("Failed to deliver the message.");
                            stream.Write(response, 0, response.Length);
                            Console.WriteLine("Response sent to client {0}: Failed to deliver the message", clientId);
                        }
                    }
                    else
                    {
                        // If the recipient client is not found or disconnected
                        // Send a response back to the sender indicating the recipient is disconnected
                        byte[] response = Encoding.ASCII.GetBytes($"Recipient is currently disconnected.");
                        stream.Write(response, 0, response.Length);
                        Console.WriteLine("Recipient client {0} is disconnected. Message not delivered {1}", recipientId, content);
                    }
                }
            }
            catch (Exception ex)
            {
                // If an error occurs while handling the client connection
                // Print an error message to the console

                // The error message includes:
                // - The client's identifier (IP address and port)
                // - The error message from the Exception object
                Console.WriteLine("Error handling client {0}: {1}",
                                  client.Client.RemoteEndPoint.ToString(),
                                  ex);
            }
            finally
            {
                // Cleanup when the client disconnects

                // Use a lock to ensure thread safety when accessing the clients array
                lock (clients)
                {
                    // Remove the client from the array
                    for (int i = 0; i < clientNum; i++)
                    {
                        // Find the client in the array
                        if (clients[i] == client)
                        {
                            // Shift all clients after the current one down by one position
                            for (int j = i; j < clientNum - 1; j++)
                            {
                                clients[j] = clients[j + 1];
                            }
                            // Decrement the client count
                            clientNum--;
                            break;
                        }
                    }
                }

                try
                {
                    // Print a message to the console indicating the client disconnected
                    Console.WriteLine("Client disconnected: {0}", client.Client.RemoteEndPoint);
                    // Close the client connection
                    client.Close();
                }
                catch (Exception ex)
                {
                    // If an error occurs while sending the disconnect message, print an error message
                    Console.WriteLine($"Error sending disconnect message: {ex.Message}");
                }
            }
        }

        private bool SendMessage(string recipientId, string message, string clientId)
        {
            // Use a lock to ensure thread safety when accessing the clients array
            lock (clients)
            {
                // Iterate through the array of connected clients
                for (int i = 0; i < clientNum; i++)
                {
                    // Get the current client
                    TcpClient recipient = clients[i];
                    // Get the client's identifier (IP address and port)
                    string recipientClientId = GetClientId(recipient);

                    // Check if the current client is the intended recipient
                    if (recipientClientId == recipientId)
                    {
                        // Check if the recipient client is still connected
                        if (recipient.Connected)
                        {
                            // Get the network stream associated with the recipient client
                            NetworkStream stream = recipient.GetStream();
                            // Convert the message to a byte array using ASCII encoding
                            byte[] data = Encoding.ASCII.GetBytes($"{clientId}#{message}");
                            // Write the message to the network stream
                            stream.Write(data, 0, data.Length);
                            // Print a message to the console indicating the message was sent
                            Console.WriteLine("Message sent to client {0}: {1}", recipientId, message);
                            // Return true to indicate successful message delivery
                            return true;
                        }
                        else
                        {
                            // If the recipient client is disconnected, print a message and return false
                            Console.WriteLine("Recipient client {0} is disconnected. Skipping message delivery.", recipientId);
                            return false;
                        }
                    }
                }
            }
            // If the recipient client is not found, return false
            return false;
        }

        private string GetClientId(TcpClient client)
        {
            try
            {
                // Check if the client is not null and connected
                if (client != null && client.Connected)
                {
                    // Get the remote endpoint (IP address and port) of the client
                    string remoteEndPoint = client.Client.RemoteEndPoint.ToString();
                    // Return the remote endpoint as a string
                    return remoteEndPoint;
                }
            }
            catch (Exception ex)
            {
                // If an error occurs, print an error message to the console
                Console.WriteLine("Error getting client ID: " + ex.Message);
            }

            // If the client is null or not connected, return null
            return null;
        }

        /*static void Main()
        {
            int port = 32332; // Replace with the desired port number
            PeerToPeerServer server = new PeerToPeerServer();
            server.Start(port);

            // Keep the server running until a key is pressed
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.Stop();
        }*/

    }
}