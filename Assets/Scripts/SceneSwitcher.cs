using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*****
 *
 * Adapted from: 
 * https://www.loekvandenouweland.com/content/use-unity-button-to-change-between-scenes.html
 *
*****/

public class SceneSwitcher : MonoBehaviour
{
    public void GotoMain(){
        SceneManager.LoadScene("Main");
    }

    public void GotoMenu(){
        SceneManager.LoadScene("Menu");
    }
}
