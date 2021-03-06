using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*****
 *
 * Timer functionality adapted from: 
 * https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
 *
 * And:
 * https://www.youtube.com/watch?v=HmHPJL-OcQE
 *
*****/


public class Timer : MonoBehaviour
{

    [SerializeField]
    private float timeRemaining = 300;

    private bool runTimer = true;
    public Text timeText;


    private void Start()
    {

    }

    void Update()
    {
        if(runTimer){
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }

            else {
                timeRemaining = 0;
                runTimer = false;

                SceneManager.LoadScene("GameOver");

            }
        }

    }

    void DisplayTime(float timeToDisplay)
    {

        if(timeToDisplay < 0)
            timeToDisplay = 0;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = timeToDisplay % 1 * 1000;
        timeText.text = string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }
}
