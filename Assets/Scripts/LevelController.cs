using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{

    public Button level1;
    public Button level2;
    public Button level3;

    // Start is called before the first frame update
    void Start()
    {
        SetLevels();

        level1.interactable = true;

        if (PlayerPrefs.GetInt("Level1") == 1)
        {
            level2.interactable = true;
        }
        else
        {
            level2.interactable = false;
  
        }

        if(PlayerPrefs.GetInt("Level2") == 1)
        {
            level3.interactable = true;
        }
        else
        {
            level3.interactable = false;
        }

        if(PlayerPrefs.GetInt("Level3") == 1)
        {
            // Game WON!
        }
    }

    private void SetLevels()
    {
        if (!PlayerPrefs.HasKey("Level1"))
        {
            PlayerPrefs.SetInt("Level1", 0);
        }

        if (!PlayerPrefs.HasKey("Level2"))
        {
            PlayerPrefs.SetInt("Level2", 0);
        }

        if (!PlayerPrefs.HasKey("Level3"))
        {
            PlayerPrefs.SetInt("Level3", 0);
        }
    }

}
