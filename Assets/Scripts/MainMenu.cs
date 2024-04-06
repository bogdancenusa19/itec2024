using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using Image = UnityEngine.UI.Image;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI money;
    [SerializeField] private GameObject inventory;
    [SerializeField] private Animator inventoryPopup;

    [SerializeField] private GameObject playerMenu;
    [SerializeField] private GameObject playerInventory;
    private void Start()
    {
        money.text = PlayerPrefs.GetInt("playerMoney").ToString();
    }

    public void Play(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Inventory()
    {
        inventory.SetActive(true);
        Invoke("SetActiveLate", 0.7f);
    }

    public void CloseInventory()
    {
        inventoryPopup.SetTrigger("Reverse");
        Invoke("SetInventoryHiddenLate", 1.2f);
        Invoke("SetPlayerBackToMainIdle", 0.4f);
    }

    private void SetPlayerBackToMainIdle()
    {
        playerInventory.SetActive(false);
        playerMenu.SetActive(true);
    }
    private void SetInventoryHiddenLate()
    { 
        inventory.SetActive(false);
    }
    private void SetActiveLate()
    {
         playerMenu.SetActive(false);
         playerInventory.SetActive(true);
    }
    
}
