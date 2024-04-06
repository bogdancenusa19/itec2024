using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    private int playerMoney;

    [SerializeField] private TextMeshProUGUI moneyUI;
    [SerializeField] private Item[] items = new Item[6];
    [SerializeField] private GameObject inventoryContent;

    private void Start()
    {
        playerMoney = PlayerPrefs.GetInt("playerMoney");
    }

    public void PurchaseItem(int index)
    {
        int value = playerMoney - items[index].GetItemPrice();
        
        if (playerMoney >= items[index].GetItemPrice())
        {
            PlayerPrefs.SetInt("playerMoney", value);
            moneyUI.text = value.ToString(); 
            items[index].transform.SetParent(inventoryContent.transform);
            items[index].PrepareItemForInventory();
        }
       
    }
}
