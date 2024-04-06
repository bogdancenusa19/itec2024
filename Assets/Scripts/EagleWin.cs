using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EagleWin : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerPrefs.SetInt("Level2", 1);

            SceneManager.LoadScene("MainMenu");
        }
    }
}
