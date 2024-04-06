using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private GameObject playerBag;
    private bool bagHasMoney = false;
    private int playerMoney = 0;
    private int coinValue = 10;

    private void Start()
    {
        playerMoney = PlayerPrefs.GetInt("playerMoney");
    }

    private void EraseMoney()
    {
        playerMoney = 0;
        PlayerPrefs.SetInt("playerMoney", 0);
        bagHasMoney = false;
    }

    private void SetMoney(int value)
    {
        playerMoney += value;
        PlayerPrefs.SetInt("playerMoney", playerMoney);
        bagHasMoney = true;
    }

    public bool GetHasMoney()
    {
        return bagHasMoney;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            SetMoney(coinValue);
        }
    }
}
