using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gunEndpoint;
    private float timeBetweenSpawns = 1f;
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
       instantiatedBullet = Instantiate(bullet, gunEndpoint.position , gunEndpoint.rotation);
       BulletVelocity bulletVelocity = instantiatedBullet.GetComponent<BulletVelocity>();
       bulletVelocity.SetCorrectScaleForEnemies(gameObject);
       bulletVelocity.SetDamage(damage);

    }
    
}
