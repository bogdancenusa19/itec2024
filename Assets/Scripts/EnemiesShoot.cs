using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesShoot : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gunEndpoint;
    private float timeBetweenSpawns = 1f;
    private float nextSpawnTime = 0f;

    private AIMovement enemyAi;

    private void Start()
    {
        enemyAi = GetComponent<AIMovement>();
    }

    private void Update()
    {
        if (enemyAi.CanShootPlayer())
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
        Instantiate(bullet, gunEndpoint.position , gunEndpoint.rotation);
    }
}
