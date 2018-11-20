using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpBox : MonoBehaviour {
    public float addXp;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * 2.5f, Space.World);
	}
    private void OnTriggerEnter(Collider other)
    {
        print("Added Experience");
        Character.experience += 10;
        Destroy(this.gameObject);
    }
}
