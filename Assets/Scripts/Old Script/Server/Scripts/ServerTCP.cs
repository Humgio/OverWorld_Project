using System;
using System.Net;
using System.Net.Sockets;

    class ServerTCP
    {
    private TcpListener serverSocket;

    public Clients[] Client = new Clients[5];
    public void InitNetwork()
    {
        serverSocket = new TcpListener(IPAddress.Any, 5353);
        serverSocket.Start();
        serverSocket.BeginAcceptTcpClient(ClientConnectCallBack, null);
    }

    public void ClientConnectCallBack(IAsyncResult result)
    {
        TcpClient tempClient = serverSocket.EndAcceptTcpClient(result);
        serverSocket.BeginAcceptTcpClient(ClientConnectCallBack, null);

        for (int i = 1; i < Client.Length; i++)
        {
            if (Client[i].socket == null)
            {
                Client[i].socket = tempClient;
                Client[i].ConnectionID = i;
                Client[i].ip = tempClient.Client.RemoteEndPoint.ToString();
                Client[i].Start();
                Console.WriteLine("Incomming Connection from" + Client[i].ip + "|| Index: " + i);
                //SendWelcomeMessage
                return;
            }
        }
    }
}
