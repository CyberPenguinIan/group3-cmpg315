using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class P2PServer
{
    public delegate void MessageReceivedEventHandler(object sender, string message);
    public event MessageReceivedEventHandler MessageReceived;

    private Socket _listener;
    private IPEndPoint _localEndPoint;

    public P2PServer(string ipAddress, int port)
    {
        // Establish the local endpoint for the socket.
        _localEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);

        // Create a TCP/IP socket.
        _listener = new Socket(_localEndPoint.AddressFamily,
            SocketType.Stream, ProtocolType.Tcp);
    }

    public void Start()
    {
        try
        {
            // Bind the socket to the local endpoint and listen for incoming connections.
            _listener.Bind(_localEndPoint);
            _listener.Listen(10);

            Console.WriteLine("P2P Server is listening on {0}", _localEndPoint);

            while (true)
            {
                Console.WriteLine("Waiting for a connection...");
                // Program is suspended while waiting for an incoming connection.
                Socket handler = _listener.Accept();
                Console.WriteLine("Connected!");

                // Start a new thread to handle the client communication.
                Thread clientThread = new Thread(() =>
                {
                    HandleClient(handler);
                });
                clientThread.Start();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    private void HandleClient(Socket handler)
    {
        string data = null;
        byte[] bytes = new byte[1024];

        try
        {
            
            while (true)
            {
                int bytesRec = handler.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                if (data.IndexOf("<EOF>") > -1)
                {
                    break;
                }
            }

            Console.WriteLine("Text received : {0}", data);

            // Echo the data back to the client.
            byte[] msg = Encoding.ASCII.GetBytes(data);
            handler.Send(msg);

            // Release the socket.
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        // Raise the MessageReceived event with the received message
        MessageReceived?.Invoke(this, data);
    }
    public void SendMessage(string ipAddress, int port, string message)
    {
        using (Socket sender = new Socket(_localEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
        {
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            sender.Connect(remoteEndPoint);
            Console.WriteLine("Connected to {0}", sender.RemoteEndPoint.ToString());

            byte[] msg = Encoding.ASCII.GetBytes(message + "<EOF>");
            sender.Send(msg);

            sender.Shutdown(SocketShutdown.Both);
        }
    }

    public void Stop()
    {
        // Stop listening for new clients.
        _listener.Close();
    }
}