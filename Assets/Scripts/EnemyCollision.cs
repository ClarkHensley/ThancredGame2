using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private string PLAYER_TAG = "Player";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag(PLAYER_TAG)){

            if(collision.collider.GetType() == typeof(UnityEngine.CircleCollider2D)){

            Debug.Log("Enemy Hit");
            transform.position += new Vector3(1000.0f, 1000.0f, 0.0f);

            }
        }
    }
}
