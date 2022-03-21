using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VicButton : MonoBehaviour
{
    public void BacktoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
