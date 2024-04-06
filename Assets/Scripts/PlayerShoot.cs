using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform[] endpoints = new Transform[2];
    private GameObject instantiatedBullet;
    private int index = 0;

    [SerializeField] private int damage;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
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

    // Calculează direcția forward relativă la world space, folosind transform.forward a endpoint-ului
    Vector2 forwardDirection = endpoints[index].right; // Pentru obiectele 2D, "right" este adesea folosit ca forward
    bulletVelocity.SetDirection(forwardDirection.normalized);
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