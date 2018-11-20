using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;
    public int maxDistance;

    private Transform myTransform;

    private void Awake()
    {
        myTransform = transform;
    }
    private void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");

        target = go.transform;

        maxDistance = 2;
    }
    private void Update()
    {
        Debug.DrawLine(target.transform.position, myTransform.position,Color.red);

        //Rotates torwards target
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position),rotationSpeed*Time.deltaTime);

        if (Vector3.Distance(target.position,myTransform.position)>maxDistance)
        {
            //Move to Target
            myTransform.position += myTransform.forward *moveSpeed* Time.deltaTime;
        }
    }
}
