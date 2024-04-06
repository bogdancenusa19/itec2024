using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPistol;
    [SerializeField] private GameObject shotgunBullet;
    private GameObject bullet;
    [SerializeField] private Transform[] endpoints = new Transform[2];
    [SerializeField] private float accuracy = 100f; 
    [SerializeField] private GameObject isPaused; 
    private GameObject instantiatedBullet;
    private Rigidbody2D rb;

    private int index = 0;

    [SerializeField] private int damage;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!gameObject.GetComponent<UpdatePlayer>().GetIsUsingPistol())
        {
            bullet = shotgunBullet;
        }
        else
        {
            bullet = bulletPistol;
        }
        
        if (Input.GetMouseButtonDown(0) && !isPaused.activeSelf)
        {
                SpawnBullet();
        }
    }

    private void SpawnBullet()
    {
        if (index >= endpoints.Length)
        {
            index = 0;
        }

        instantiatedBullet = Instantiate(bullet, endpoints[index].position, endpoints[index].rotation);
        BulletVelocity bulletVelocity = instantiatedBullet.GetComponent<BulletVelocity>();

        // Direcția inițială
        Vector2 forwardDirection = endpoints[index].right.normalized;
        if (gameObject.transform.localScale.x < 0)
        {
            forwardDirection = -endpoints[index].right.normalized;
        }

        // Calculăm deviația pe baza acurateței
        float deviation = 1f - accuracy / 100f; // Calculăm procentul de deviație
        float angleDeviation = Random.Range(-deviation, deviation) * 45f; // Max 45 de grade de deviație
        Quaternion rotationDeviation = Quaternion.Euler(0, 0, angleDeviation);
        Vector2 adjustedDirection = rotationDeviation * forwardDirection;

        bulletVelocity.SetDirection(adjustedDirection);
        bulletVelocity.SetDamage(damage);

        Collider2D playerCollider = GetComponent<Collider2D>();
        Collider2D bulletCollider = instantiatedBullet.GetComponent<Collider2D>();
        if (playerCollider != null && bulletCollider != null)
        {
            Physics2D.IgnoreCollision(playerCollider, bulletCollider);
        }

        index++;
    }
    
}