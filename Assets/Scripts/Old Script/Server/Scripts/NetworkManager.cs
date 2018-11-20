using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
        ServerTCP serverTCP = new ServerTCP();
        serverTCP.InitNetwork();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
