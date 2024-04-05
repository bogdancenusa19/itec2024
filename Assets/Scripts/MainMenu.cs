using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Image playerImage;
    
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Store()
    {
        //open store
    }

    public void UpgradePlayer()
    {
        //upgrade player
    }
}
