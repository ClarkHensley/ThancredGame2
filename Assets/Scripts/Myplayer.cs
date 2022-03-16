using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Myplayer : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    [SerializeField]
    private float rotationAmount = 2.0f;

    private float movementX;
    private float movementY;
    private float rotationZ;

    private bool upright = true;

    [SerializeField]
    private Rigidbody2D myBody;

    private bool isGrounded;
    private string GROUND_TAG = "Ground";

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(upright){
            PlayerBalance();
            PlayerMove();
            PlayerJump();
            PlayerOrient();
        
        }
    }

    void PlayerBalance()
    {
        rotationZ = transform.localRotation.eulerAngles.z;

        if(rotationZ != 0){
            if(rotationZ < 180.0f)
                transform.localRotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 0.3f);
            else if (rotationZ >= 180.0f)
                transform.localRotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + 0.3f);
        
        }
    }

    void PlayerMove()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");
        rotationZ = transform.localRotation.eulerAngles.z;

        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;

        if(movementX != 0){
            float rotationConstant = (movementX > 0) ? -1.0f : 1.0f;
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + (rotationAmount * rotationConstant));
        }

    }

    void PlayerJump()
    {
        rotationZ = transform.localRotation.eulerAngles.z;
        float rotationZRad = rotationZ * Mathf.Deg2Rad;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(Mathf.Sin(rotationZRad) * jumpForce * -1, Mathf.Cos(rotationZRad) * jumpForce), ForceMode2D.Impulse);
        }
    }

    void PlayerOrient()
    {

        movementX = Input.GetAxisRaw("Horizontal");

        Vector3 characterOrientation = transform.localScale;
        if(movementX < 0){
            characterOrientation.x = -1;
        }
        else if (movementX > 0){
            characterOrientation.x = 1;
        }

        transform.localScale = characterOrientation;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }
    }
}

