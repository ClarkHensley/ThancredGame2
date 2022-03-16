using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelCollision : MonoBehaviour
{

    private GameObject player;
    private string ENEMY_TAG = "Enemy";

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        //Debug.Log(player.GetComponent<Collider>());
        Debug.Log(GetComponent<Collider>());

        //Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");
        Debug.Log(GetComponent<Collider>());

        //Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Check for collision with an enemy
    private void OnCollissionEnter2D(Collision2D collision){

        if(collision.gameObject.CompareTag(ENEMY_TAG)){

            Debug.Log("Killed Enemy");

        }

    }
}

