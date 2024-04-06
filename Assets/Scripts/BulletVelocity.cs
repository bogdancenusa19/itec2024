using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVelocity : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float duration = 3f;

    [Header("Effects")]
    public GameObject particleEffect;

    private Vector2 shootDirection;

    private Rigidbody2D bulletRb;
    private int weaponDamage = 0;

    private Health playerHealth;
    
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        bulletRb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, duration);
    }
    
    void FixedUpdate()
    {
        bulletRb.velocity = shootDirection * bulletSpeed;
    }

    public void SetDirection(Vector2 direction)
    {
        shootDirection = direction.normalized;
    }
    
    public void SetDamage(int value)
    {
        weaponDamage = value;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(particleEffect, transform.position, Quaternion.identity);

        if (other.CompareTag("Player"))
        {
            playerHealth.TakeDamage(weaponDamage);
            if (playerHealth.GetHealth() <= 0)
            {
                playerHealth.Die();
            }
            Debug.Log(playerHealth.GetHealth());
            Destroy(gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Health>().TakeDamage(weaponDamage);
            if (other.GetComponent<Health>().GetHealth() <= 0)
            {
                other.GetComponent<Health>().Die();
            }
            Destroy(gameObject);
        }
        else if(other.CompareTag("Coin"))
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<CapsuleCollider2D>(), other);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
