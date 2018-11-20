using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientManager : MonoBehaviour {

    public static ClientManager instance;

    public static int myConnectionID;
    [SerializeField] private GameObject connectionPrefab;
    [SerializeField] private string ipAdress;
    [SerializeField] private int port;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
        UnityThread.initUnityThread();

        InitPlayer();

        ClientHandleData.InitializePackage();
        ClientTCP.instance.Connect(ipAdress, port);
    }
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);
        ClientTCP.instance.Connect(ipAdress,port);
	}
    private void OnApplicationQuit()
    {
        ClientTCP.instance.client.Close();
    }
    public static float WrapAngle(float angle)
    {
        angle %= 360;
        if (angle > 180)
            return angle - 360;

        return angle;
    }

    public static float UnwrapAngle(float angle)
    {
        if (angle >= 0)
            return angle;

        angle = -angle % 360;
        return 360 - angle;
    }
    void InitPlayer()
    {
        for (int i = 1; i < Constants.MAX_PLAYERS; i++)
        {
            Types.players[i] = new Types.PlayerRec();
        }
    }
    public void InstantiateNetworkPlayer(int connectionID)
    {
        Types.players[connectionID].playerPref = Instantiate(connectionPrefab);
        Types.players[connectionID].playerPref.name = "Player: " + connectionID;
    }
}
