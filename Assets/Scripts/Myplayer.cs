using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Myplayer : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    [SerializeField]
    private float rotationAmount = 0.5f;

    [SerializeField]
    private int numberOfTargets;

    [SerializeField]
    private string nextStage;

    private float movementX;
    private float movementY;
    private float rotationZ;

    [SerializeField]
    private Rigidbody2D myBody;

    [SerializeField]
    private float accel = 0.25f;

    [SerializeField]
    private bool doubleJump = false;

    private bool hasDoubleJumped = false;


    private float currentVelocity = 0.0f;
    private float oldMovementX = 0;

    private bool isGrounded;
    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";

    private int targetsHit = 0;
    private string TARGET_TAG = "Target";

    private string DOUBLEJUMP_TAG = "DoubleJump";

    private string SPIKE_TAG = "Spike";

    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckWin();
        PlayerBalance();
        PlayerMove();
        if (Input.GetButtonDown("Jump") && ((isGrounded) || (doubleJump && !hasDoubleJumped)))
            PlayerJump(false);
        AnimatePlayer();


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
        if(movementX != 0)
            oldMovementX = movementX;
        movementY = Input.GetAxisRaw("Vertical");
        rotationZ = transform.localRotation.eulerAngles.z;

        transform.position += new Vector3(oldMovementX, 0f, 0f) * currentVelocity * Time.deltaTime;

        if(Input.GetKey("left") || Input.GetKey("right")){
        // Accelerating

            if(currentVelocity < moveForce)
                currentVelocity += accel;
            else
                currentVelocity = moveForce;

        }
        else if(currentVelocity > 0){
        // Decelerating
            currentVelocity -= accel;

        }
        else{
            currentVelocity = 0;
            oldMovementX = 0;
        }

        if(movementX != 0){
            float rotationConstant = (movementX > 0) ? -1.0f : 1.0f;
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + (rotationAmount * rotationConstant));

        }
    }

    void PlayerJump(bool isEnemy)
    {
        rotationZ = transform.localRotation.eulerAngles.z;
        float rotationZRad = rotationZ * Mathf.Deg2Rad;

        if(isGrounded)
            isGrounded = false;
        else if(!isEnemy)
            hasDoubleJumped = true;
        myBody.AddForce(new Vector2(Mathf.Sin(rotationZRad) * jumpForce * -1, Mathf.Cos(rotationZRad) * jumpForce), ForceMode2D.Impulse);
    }

    private void CheckWin(){

        if(targetsHit >= numberOfTargets)
            SceneManager.LoadScene(nextStage);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
            hasDoubleJumped = false;
        }

        else if (collision.gameObject.CompareTag(ENEMY_TAG)){

            if(collision.otherCollider.GetType() == typeof(UnityEngine.CircleCollider2D)){
                if(!isGrounded)
                    PlayerJump(true);
            }

            else
                SceneManager.LoadScene("GameOver");

        }

        else if (collision.gameObject.CompareTag(TARGET_TAG)){

           targetsHit++;

        }

        else if (collision.gameObject.CompareTag(DOUBLEJUMP_TAG)){

            doubleJump = true;

        }

        else if (collision.gameObject.CompareTag(SPIKE_TAG)){

            SceneManager.LoadScene("GameOver");

        }


    }

    void AnimatePlayer()
    {
        if (movementX > 0) 
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
         }

        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }

        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
}
