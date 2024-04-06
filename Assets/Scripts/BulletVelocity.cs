using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVelocity : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    private Vector2 shootDirection;
    private float scaleToShoot = 0;

    private Rigidbody2D bulletRb;
    private int weaponDamage = 0;

    private Health playerHealth;
    
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        bulletRb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
        Debug.Log(scaleToShoot);
    }
    
    void FixedUpdate()
    {
        bulletRb.velocity = shootDirection * bulletSpeed;
    }

    public void SetDirection(Vector2 direction)
    {
        shootDirection = direction.normalized;
    }

    public void SetCorrectScaleForEnemies(GameObject parent)
    {
        scaleToShoot = -parent.transform.localScale.x;
    }

    public void SetCorrectScaleForPlayer(GameObject parent)
    {
        scaleToShoot = parent.transform.localScale.x;
    }

    public void SetDamage(int value)
    {
        weaponDamage = value;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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

        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Health>().TakeDamage(weaponDamage);
            if (other.GetComponent<Health>().GetHealth() <= 0)
            {
                other.GetComponent<Health>().Die();
            }
            Destroy(gameObject);
        }
    }
}
