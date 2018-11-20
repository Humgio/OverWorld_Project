using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class ClientTCP : MonoBehaviour
{
    public static ClientTCP instance;

    public TcpClient client;
    public static NetworkStream myStream;
    private byte[] asyncBuffer;
    public bool isConnected;

    public byte[] receivedBytes;
    public bool handleData = false;

    public int myConnectionID;

    private void Awake()
    {
        UnityThread.initUnityThread();
        instance = this;
    }
    public void Connect(string ip,int port)
    {
        Debug.Log("Trying to connect to the server");

        client = new TcpClient
        {
            ReceiveBufferSize = Constants.MAX_BUFFERSIZE,
            SendBufferSize = Constants.MAX_BUFFERSIZE
        };
        asyncBuffer = new byte[Constants.MAX_BUFFERSIZE * 2];

        try
        {
            client.BeginConnect(ip,port, new AsyncCallback(ConnectCallBack), client);
        }
        catch
        {
            Debug.Log("Unable to connect to the server");
        }
    }
    public void ConnectCallBack(IAsyncResult result)
    {
        try
        {
            client.EndConnect(result);
            if (client.Connected == false) { return; }
            else
            {
                myStream = client.GetStream();
                myStream.BeginRead(asyncBuffer, 0, 8192, OnReceiveData, null);
                isConnected = true;
                Debug.Log("You are connect to the server succesfully.");
            }
        }
        catch (Exception)
        {
            isConnected = false;
            throw;
        }
    }

    public void OnReceiveData(IAsyncResult result)
    {
        try
        {
            int packageLenght = myStream.EndRead(result);
            receivedBytes = new byte[packageLenght];
            Buffer.BlockCopy(asyncBuffer, 0, receivedBytes, 0, packageLenght);


            if (packageLenght == 0)
            {
                Debug.Log("Disconnected");
                UnityThread.executeInUpdate(() =>
                {
                    Application.Quit();
                });
                return;
            }
            UnityThread.executeInUpdate(() =>
            {
                ClientHandleData.HandleData(receivedBytes);
            });
            myStream.BeginRead(asyncBuffer, 0, 8192, OnReceiveData, null);
        }
        catch (Exception)
        {
            Debug.Log("Disconnected");
            UnityThread.executeInUpdate(() =>
            {
                Application.Quit();
            });
            return;
        }
    }
    public static void SendData(byte[] data)
    {
        ByteBuffer buffer = new ByteBuffer();
        buffer.WriteLong((data.GetUpperBound(0) - data.GetLowerBound(0)) + 1);
        buffer.WriteBytes(data);
        myStream.Write(buffer.ToArray(), 0, buffer.ToArray().Length);
    }

    public void SEND_MESSAGE()
    {
        ByteBuffer buffer = new ByteBuffer();
        buffer.WriteLong(((long)ClientPackage.C_MESSAGE));
        buffer.WriteString("Hey there SERVER!");
        SendData(buffer.ToArray());
    }

    public static void SendMovement(Vector3 pos, Quaternion rot)
    {
        ByteBuffer buffer = new ByteBuffer();
        buffer.WriteLong((long)ClientPackage.C_MOVEMENT);

        //position
        buffer.WriteFloat(pos.x);
        buffer.WriteFloat(pos.y);
        buffer.WriteFloat(pos.z);

        //rotation
        buffer.WriteFloat(ClientManager.UnwrapAngle(rot.x));
        buffer.WriteFloat(ClientManager.UnwrapAngle(rot.y));
        buffer.WriteFloat(ClientManager.UnwrapAngle(rot.z));

        SendData(buffer.ToArray());
        buffer.Dispose();
    }

}
