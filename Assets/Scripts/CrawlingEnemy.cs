using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlingEnemy : MonoBehaviour
{

    private string PLAYER_TAG = "Player";

    [SerializeField]
    private float range = 5.0f;

    [SerializeField]
    private float speed = 0.2f;

    private Vector3 Home;
    private int moveDir = -1;
    private bool turned = false;

    // Start is called before the first frame update
    void Start()
    {

        Home = new Vector3(transform.position.x, transform.position.y, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
       EnemyMove(); 
    }

    void EnemyMove(){


        if(Vector3.Distance(Home, transform.position) < range || turned){
            transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime * moveDir;
            if(turned)
                turned = false;
        }
        else{
            Vector3 currentOrientation = transform.localScale;
            currentOrientation.x = -1 * currentOrientation.x;
            transform.localScale = currentOrientation;
            turned = true;

            moveDir = -1 * moveDir;

            transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime * moveDir;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag(PLAYER_TAG)){

            if(collision.collider.GetType() == typeof(UnityEngine.CircleCollider2D)){

            transform.position += new Vector3(1000.0f, 1000.0f, 0.0f);

            }
        }
    }
}
