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

    [SerializeField] private GameObject bloodParticles;
    

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
        Debug.Log("Take Damage!");
        Instantiate(bloodParticles, transform.position, Quaternion.identity);
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
