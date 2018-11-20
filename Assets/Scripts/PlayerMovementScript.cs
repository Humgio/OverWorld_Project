using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
    public float rotationSpeed;
    public float jumpForce;
    [SerializeField]
    private bool isGrounded = true;
    [SerializeField]
    private bool doubleJump = true;
    private bool jumpSkill = false;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        speed = 5f;
        rotationSpeed = 100f;
        jumpForce = 10f;
        //speed = Character.speed;
        //jumpForce = Character.jumpForce;
	}
    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w"))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * speed * 2.5f;
        } else if(Input.GetKey("w") && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * speed;
        } else if (Input.GetKey("s"))
        {
            transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * speed;
        }

        if (Input.GetKey ("a") && !Input.GetKey("d"))
        {
            transform.Rotate(Vector3.up *Time.deltaTime * -rotationSpeed);
        } else if(Input.GetKey("d") && !Input.GetKey("a"))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(Vector3.up * jumpForce);
        }
        if(Input.GetKeyDown(KeyCode.Space) && !isGrounded && doubleJump && jumpSkill)
        {
            doubleJump = false;
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        doubleJump = false;
    }
    private void OnCollisionExit(Collision collision)
    {
        doubleJump = true;
        isGrounded = false;
    }
}
