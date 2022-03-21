using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public float speed;
    private string PLAYER_TAG = "Player";

    private bool isGrounded;
    private string GROUND_TAG = "Ground";

    [SerializeField]
    private float jumpForce = 7f;

    private Rigidbody2D myBody;

    // Start is called before the first frame update
    void Awake()
    {
         myBody = GetComponent<Rigidbody2D>();
        speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
        EnemyJump();
    }

    void EnemyJump()
    {
       if(isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(PLAYER_TAG))
        {

            if (collision.collider.GetType() == typeof(UnityEngine.CircleCollider2D))
            {

                transform.position += new Vector3(1000.0f, 1000.0f, 0.0f);

            }
        }

        if(collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded=true;
        }
    }
}
