using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizMotion = Input.GetAxis("Horizontal");
        float vertMotion = Input.GetAxis("Vertical");

        // Move L/R with arrow keys
        transform.Translate(horizMotion * 8f * Time.deltaTime, 0f, 0f);

        if(vertMotion > 0){
            transform.Translate(0f, vertMotion * 8f * Time.deltaTime, 0f);
        }

        // Flip the sprite based on direction of motion
        Vector3 characterOrientation = transform.localScale;

        if(horizMotion < 0){
            characterOrientation.x = -1;
        }
        else if(horizMotion > 0){
            characterOrientation.x = 1;
        }

        transform.localScale = characterOrientation;

    }

}
