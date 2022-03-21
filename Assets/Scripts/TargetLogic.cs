using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLogic : MonoBehaviour
{

    private string PLAYER_TAG = "Player";

    [SerializeField]
    private float startingx = -1.0f;

    [SerializeField]
    private float startingy = 1.3f;

    private Vector3 Home;

    // Start is called before the first frame update
    void Start()
    {

        Home = new Vector3(startingx, startingy, 0.0f);
        transform.position = Home;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision){

        if (collision.gameObject.CompareTag(PLAYER_TAG)){
            
            Debug.Log("Got a Goal");
            transform.position += new Vector3(1000.0f, 1000.0f, 0.0f);


        }

    }
}
