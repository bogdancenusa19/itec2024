using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Canvas storeCanvas;
    
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Store()
    {
        storeCanvas.gameObject.SetActive(true);
    }

    public void CloseStore()
    {
        storeCanvas.gameObject.SetActive(false);
    }

    public void UpgradePlayer()
    {
        //upgrade player
    }
}
