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
   private string inventoryText = "Equip";
   [SerializeField] private Image backgroundImage;
   [SerializeField] private Image equipImage;
   [SerializeField] private Color inventoryColor = new Color(0f, 0.870f, 1f, 1f);
   [SerializeField] private Color equipColor = new Color(0f, 0.278f, 1f, 1f);
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
      backgroundImage.color = inventoryColor;
      backgroundImage.color = new Color(0f, 0.870f, 1f, 1f);
      equipImage.color = equipColor;
      equipImage.color = new Color(0f, 0.278f, 1f, 1f);
      Destroy(coinImage);
   }
}
