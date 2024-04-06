using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gunEndpoint;
    [SerializeField] private float timeBetweenSpawns = 1f;
    private float nextSpawnTime = 0f;
    private GameObject instantiatedBullet;

    [SerializeField] private int damage;

    private AIMovement enemyAI;

    private void Start()
    {
        enemyAI = GetComponent<AIMovement>();
    }

    private void Update()
    {
        if (enemyAI.CanShootPlayer())
        {
            if (Time.time > nextSpawnTime)
            {
                SpawnBullet();
                nextSpawnTime = Time.time + timeBetweenSpawns;
            }
        }
    }

    private void SpawnBullet()
{
    instantiatedBullet = Instantiate(bullet, gunEndpoint.position, gunEndpoint.rotation);
    BulletVelocity bulletVelocity = instantiatedBullet.GetComponent<BulletVelocity>();
    Vector2 forwardDirection = -gunEndpoint.right;
    if (gameObject.transform.localScale.x < 0)
    {
        forwardDirection = gunEndpoint.right;
    }
    
    bulletVelocity.SetDirection(forwardDirection.normalized);
    bulletVelocity.SetDamage(damage);

    Collider2D enemyCollider = GetComponent<Collider2D>();
    Collider2D bulletCollider = instantiatedBullet.GetComponent<Collider2D>();
    if (enemyCollider != null && bulletCollider != null)
    {
        Physics2D.IgnoreCollision(enemyCollider, bulletCollider);
    }
}

    public void SetDamage(int damage)
    {
        this.damage = damage;
}

    
}
