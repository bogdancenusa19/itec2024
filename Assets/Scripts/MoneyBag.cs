using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBag : MonoBehaviour
{
    [SerializeField] private Sprite defaultBag;
    [SerializeField] private Sprite fullMoneyBag;

    private Money playerMoney;

    private void Start()
    {
        playerMoney = gameObject.GetComponentInParent<Money>();
    }

    private void Update()
    {
        if (playerMoney.GetHasMoney())
        {
            SetFullMoneyBag();
        }
        else
        {
            SetDefaultBag();
        }
    }

    public void SetDefaultBag()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = defaultBag;
    }

    public void SetFullMoneyBag()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = fullMoneyBag;
    }
}
