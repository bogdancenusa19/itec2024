using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;

    [SerializeField] private bool isThisPlayer = false;

    [SerializeField] private Slider _slider;
    

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (isThisPlayer)
        {
            _slider.value = currentHealth; 
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateUI();
    }

    public void Heal(int ammount)
    {
        currentHealth += ammount;
        UpdateUI();
    }

    public void Die()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int GetHealth()
    {
        return currentHealth;
    }
}
