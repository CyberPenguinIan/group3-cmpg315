using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace GroupServ
{
    public class GroupServer
    {
        // Declare a TcpListener object to listen for incoming connections
        private TcpListener listener;

        // Declare an array of TcpClient objects to store connected clients
        private TcpClient[] clients;

        // Declare an array of Thread objects to manage client communication
        private Thread[] clientThreads;

        // Declare a boolean flag to indicate whether the server is running
        private bool Running;

        // Declare an integer to keep track of the number of connected clients
        private int clientNum;

        public GroupServer()
        {
            // Initialize the clients array to store up to 100 TcpClient objects
            clients = new TcpClient[100]; // Maximum 100 clients

            // Initialize the clientThreads array to store up to 100 Thread objects
            clientThreads = new Thread[100]; // Maximum 100 threads

            // Set the Running flag to true, indicating the server is starting up
            Running = true;

            // Initialize the clientNum variable to 0, indicating no clients are connected
            clientNum = 0;
        }

        public void Start(int port)
        {
            try
            {
                // Set up the server socket to listen on the specified port
                IPAddress ipAddress = IPAddress.Any; // Listen on all available network interfaces
                listener = new TcpListener(ipAddress, port);

                // Start listening for incoming connections
                listener.Start();
                Console.WriteLine("Server started on port {0}", port);

                while (Running)
                {
                    // Accept a new client connection
                    TcpClient client = listener.AcceptTcpClient();
                    clients[clientNum] = client;
                    Console.WriteLine("Client connected: {0}", client.Client.RemoteEndPoint);

                    // Create a new thread to handle communication with the client
                    clientThreads[clientNum] = new Thread(new ParameterizedThreadStart(HandleClient));
                    clientThreads[clientNum].Start(client);
                    clientNum++;

                    // Send a message to all other clients that a new client has joined
                    for (int i = 0; i < clientNum; i++)
                    {
                        NetworkStream joinedStream = clients[i].GetStream();
                        byte[] data = Encoding.ASCII.GetBytes($"({client.Client.RemoteEndPoint.ToString()})#Joined the chat!");
                        joinedStream.Write(data, 0, data.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Stop()
        {
            try
            {
                // Set the Running flag to false to indicate the server is stopping
                Running = false;

                // Close all client connections and threads
                for (int i = 0; i < clientNum; i++)
                {
                    // Close the client connection
                    clients[i].Close();

                    // Wait for the client thread to finish
                    clientThreads[i].Join();
                }

                // Stop the server socket
                listener.Stop();
                Console.WriteLine("Server stopped");
            }
            catch (Exception ex)
            {
                // Catch any exceptions that occur during the shutdown process
                Console.WriteLine(ex.Message);
            }
        }

        private void HandleClient(object obj)
        {
            // Cast the object to a TcpClient
            TcpClient client = obj as TcpClient;

            // Get the network stream associated with the client
            NetworkStream stream = client.GetStream();

            try
            {
                while (Running)
                {
                    // Receive a message from the client
                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    string[] items = message.Split(new[] { '#' }, 2);
                    string username = items[0];
                    message = items[1];

                    // If no data was received, break out of the loop
                    if (bytesRead == 0)
                        break;

                    // Send the message to all other clients
                    for (int i = 0; i < clientNum; i++)
                    {
                        if (clients[i] != client)
                        {
                            NetworkStream otherStream = clients[i].GetStream();
                            byte[] data = Encoding.ASCII.GetBytes($"{username}#{message}");
                            otherStream.Write(data, 0, data.Length);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Catch any exceptions that occur during client handling
                Console.WriteLine("Error handling client {0}: {1}", client.Client.RemoteEndPoint, ex.Message);
            }
            finally
            {
                // Cleanup when the client disconnects

                // Find the client in the clients array and remove it
                for (int i = 0; i < clientNum; i++)
                {
                    if (clients[i] == client)
                    {
                        for (int j = i; j < clientNum - 1; j++)
                        {
                            clients[j] = clients[j + 1];
                            clientThreads[j] = clientThreads[j + 1];
                        }
                        clientNum--;
                        break;
                    }
                }

                try
                {
                    // Send a message to all other clients announcing the client's departure
                    for (int i = 0; i < clientNum; i++)
                    {
                        NetworkStream joinedStream = clients[i].GetStream();
                        byte[] data = Encoding.ASCII.GetBytes($"({client.Client.RemoteEndPoint})#Left the chat!");
                        joinedStream.Write(data, 0, data.Length);
                    }
                    Console.WriteLine("Client disconnected: {0}", client.Client.RemoteEndPoint);
                }
                catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
            }
        }

        /*static void Main()
        {
            int port = 23223; // Replace with the desired port number
            GroupServer server = new GroupServer();
            server.Start(port);

            // Keep the server running until a key is pressed
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.Stop();
        }*/
    }
}
