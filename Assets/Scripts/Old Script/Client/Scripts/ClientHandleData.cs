using System.Collections.Generic;
using UnityEngine;

public class ClientHandleData : MonoBehaviour {

    public static Dictionary<int, GameObject> playerList = new Dictionary<int, GameObject>();
    public GameObject playerPref;
    public static GameObject playerPref_;

    public static ByteBuffer playerBuffer;
    private delegate void Package_(byte[] data);
    private static Dictionary<long, Package_> packages;
    private static long pLenght;

    private void Awake()
    {
        InitializePackage();
        playerPref_ = playerPref;
    }

    public static void InitializePackage()
    {
        packages = new Dictionary<long, Package_>
        {
            {(long)ServerPackage.S_INFORMATION, PACKAGE_INFORMATION },
            {(long)ServerPackage.S_SENDINGAME, PACKAGE_INGAME },
            {(long)ServerPackage.S_PLAYERDATA, PACKAGE_PLAYERDATA },
            {(long)ServerPackage.S_PLAYERMOVE, PACKAGE_PLAYERMOVE },
        };
    }

    public static void HandleData(byte[] data)
    {
        byte[] Buffer;
        Buffer = (byte[])data.Clone();

        if(playerBuffer == null) { playerBuffer = new ByteBuffer(); };
        playerBuffer.WriteBytes(Buffer);

        if (playerBuffer.Count() == 0)
        {
            playerBuffer.Clear();
            return;
        }

        if (playerBuffer.Lenght() >= 8)
        {
            pLenght = playerBuffer.ReadLong(false);
            if (pLenght <= 0)
            {
                playerBuffer.Clear();
                return;
            }
        }
        while (pLenght > 0 & pLenght <= playerBuffer.Lenght() - 8)
        {
            if (pLenght <= playerBuffer.Lenght() - 8)
            {
                playerBuffer.ReadLong(); //Reads out th packet identifier.
                data = playerBuffer.ReadBytes((int)pLenght); // Gets the full package lenght.
                HandleDataPackage(data);
            }

            pLenght = 0;

            if (playerBuffer.Lenght() >= 8)
            {
                pLenght = playerBuffer.ReadLong(false);

                if (pLenght < 0 )
                {
                    playerBuffer.Clear();
                    return;
                }
            }
        }
    }
    private static void HandleDataPackage(byte[] data)
    {
        long packageIdentifier; ByteBuffer buffer;
        Package_ package;

        buffer = new ByteBuffer();
        buffer.WriteBytes(data);
        packageIdentifier = buffer.ReadLong();
        buffer.Dispose();

        if (packages.TryGetValue(packageIdentifier, out package))
        {
            package.Invoke(data);
        }
    }
    private static void HandleIngame(byte[] data)
    {
        ByteBuffer buffer = new ByteBuffer();
        buffer.WriteBytes(data);
        buffer.ReadInteger();
        ///////REWRITE!\\\\\\\\
        //ClientManager.instance.myConnectionID = buffer.ReadInteger();
    }
    private static void PACKAGE_INFORMATION(byte[] data)
    {
        ByteBuffer buffer = new ByteBuffer();
        buffer.WriteBytes(data);

        long packageIdentifier = buffer.ReadLong();
        int connectionID = buffer.ReadInteger();
        string msg1 = buffer.ReadString();
        string msg2 = buffer.ReadString();
        int level = buffer.ReadInteger();

        Debug.Log(msg1);
        Debug.Log(msg2);
        Debug.Log(level);

        ClientTCP.instance.SEND_MESSAGE();
    }
    private static void PACKAGE_INGAME(byte[] data)
    {
        Debug.Log("I am getting executed by the server");
        ByteBuffer buffer = new ByteBuffer();
        buffer.WriteBytes(data);

        long packageIdentifier = buffer.ReadLong();
        int connectionID = buffer.ReadInteger();
        Globals.myConnectionID = connectionID;
    }

    static void PACKAGE_PLAYERDATA(byte[] data)
    {
        ByteBuffer buffer = new ByteBuffer();
        buffer.WriteBytes(data);

        long packageIdentifier = buffer.ReadLong();
        int connectionID = buffer.ReadInteger();

        GameObject tempPlayer = playerPref_;
        tempPlayer.name = "Player: " + connectionID;
        //tempPlayer.GetComponent<Player>().connectionID = connectionID;
        playerList.Add(connectionID,tempPlayer);

        Instantiate(tempPlayer);
    }
    static void PACKAGE_PLAYERMOVE(byte[] data)
    {
        ByteBuffer buffer = new ByteBuffer();
        buffer.WriteBytes(data);

        long packageIdentifier = buffer.ReadLong();

        int connectionID = buffer.ReadInteger();

        float x = buffer.ReadFloat();
        float y = buffer.ReadFloat();
        float z = buffer.ReadFloat();

        float rotx = buffer.ReadFloat();
        float roty = buffer.ReadFloat();
        float rotz = buffer.ReadFloat();

        //GameObject player = playerList[connectionID];
        GameObject player = GameObject.Find("Player: " + connectionID + "(Clone)");
        player.transform.position = new Vector3(x, y, z);
        player.transform.eulerAngles = new Vector3(ClientManager.WrapAngle(rotx), ClientManager.WrapAngle(roty), ClientManager.WrapAngle(rotz));
        buffer.Dispose();
    }
}
