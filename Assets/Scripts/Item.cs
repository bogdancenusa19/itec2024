using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
   [SerializeField] private int price;
   [SerializeField] private TextMeshProUGUI textPrice;
   private string inventoryText = "EQUIP";
   [SerializeField] private GameObject buyButton;
   [SerializeField] private GameObject equipButton;
   [SerializeField] private Image coinImage;

   private void Start()
   {
      textPrice.text = "Buy for " + price;
   }

   public int GetItemPrice()
   {
      return price;
   }

   public void PrepareItemForInventory()
   {
      textPrice.text = inventoryText;
      buyButton.SetActive(false);
      equipButton.SetActive(true);
      Destroy(coinImage);
   }
}
