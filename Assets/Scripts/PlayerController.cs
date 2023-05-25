//Haley Beyersdoerfer
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Private Variables
    public float speed = 20;
    public float turnSpeed = 20;
    public float shift = 2;
    public float jumpSpeed = 10;

    private Vector3 StartPosition;
    private Rigidbody rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
        rigidbody = GetComponent<Rigidbody>();
    }

    void HandleMovement()
    {
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float gas = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float jump = Input.GetAxis("Jump") * jumpSpeed * Time.deltaTime;

        turn *= Mathf.Sign(gas);
        if(gas == 0)
        {
            turn = 0;
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            turn *= shift;
            gas *= shift;
        }
        Vector3 positionChange = Vector3.forward * gas;
        positionChange += Vector3.up * jump;

        transform.Rotate(Vector3.up, turn);
        transform.Translate(positionChange);
    }

    void HandleResetPosition()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                ResetPosition(StartPosition);
            }
            else
            {
                ResetPosition();
            }
        }
    }

    void ResetPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
        transform.rotation = Quaternion.identity;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }

    void ResetPosition()
    {
        Vector3 newPos = transform.position;
        newPos.y = 10;
        ResetPosition(newPos);
    }

    // Update is called once per frame
    void Update()
    {
        HandleResetPosition();
        HandleMovement();
    }
}
