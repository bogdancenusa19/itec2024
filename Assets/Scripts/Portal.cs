using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private int indexOfNextScene;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("LoadLate", 1f);
        }
    }

    private void LoadLate()
    {
        LoadScene(indexOfNextScene);
    }

    private void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
