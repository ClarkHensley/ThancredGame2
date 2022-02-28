using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int getUp = 0;
    public bool jumpStarted = false;
    public int jumpFrames = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Store current motion in horizontal and vertical directions
        float horizMotion = Input.GetAxis("Horizontal");
        float vertMotion = Input.GetAxis("Vertical");
        Debug.Log(vertMotion);

        // Get the current rotation on the z axis. For our purposes, that's any rotation
        float currRotation = transform.localRotation.eulerAngles.z;
        // Rotation difference from 360 degrees
        float rotationOffset = 360.0f - Math.Abs(currRotation);
        // Is the sprite "upright" and not falling over
        bool upright = rotationOffset <= 45.0f || rotationOffset >= 315.0f;

        // Increment the counter for "getting up" if the sprite has fallen
        if(!upright) getUp++;

        // Continue a jump for 30 frames
        if(jumpStarted && vertMotion == 0 && jumpFrames >= 30){
            jumpStarted = false;
            jumpFrames = 0;
        }

        // Get the player up
        if(getUp >= 180){//} && vertMotion == 0){
            // Player Gets up
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, Math.Abs(currRotation + rotationOffset));
            getUp = 0;
        }

        // Move L/R with arrow keys
        if(upright){
            transform.Translate(horizMotion * 8f * Time.deltaTime, 0f, 0f);

            // Rotate the player slightly in the direction they're moving
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, currRotation + ((vertMotion >= 0) ? -2.0f * horizMotion : 15.0f * horizMotion));

        }

        // Initiate a jump
        if((!jumpStarted && vertMotion > 0) || ( jumpStarted && jumpFrames < 30)){
            jumpStarted = true;
            transform.Translate(0f, vertMotion * 8f * Time.deltaTime, 0f);
            jumpFrames++;
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
