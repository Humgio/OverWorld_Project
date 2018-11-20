using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent(typeof(ItemValue)))
        {
            print("You picked "+ other.GetComponent<ItemValue>().wepName);
            other.GetComponent<ItemValue>().setOwner(this.name);
        }
    }
}
