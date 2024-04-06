using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class MainMenu : MonoBehaviour
{    
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void UpgradePlayer()
    {
        //upgrade player
    }
}
