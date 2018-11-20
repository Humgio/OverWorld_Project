using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraScript : MonoBehaviour
{
    public Transform target;
    public float distance;
    public float height;
    public float rotationSpeed;

    private Transform _myTransform;
    private Vector3 offSetX;

    // Use this for initialization
    void Start()
    {
        if (target == null)
        {
            Debug.LogWarning("There is no target to target!");
        }
        _myTransform = transform;
        offSetX = new Vector3(0, height, distance);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
        {
            offSetX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up) * offSetX;
        }
        _myTransform.position = target.position + offSetX;
        _myTransform.LookAt(target.position);
    }
}
