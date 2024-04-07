using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPistol;
    [SerializeField] private GameObject shotgunBullet;
    private bool isShotgun = false;
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
            isShotgun = true;
        }
        else
        {
            bullet = bulletPistol;
            isShotgun = false;
        }

        if (Input.GetMouseButtonDown(0) && !isPaused.activeSelf)
        {
            if (isShotgun)
            {
                List<Collider2D> bulletColliders = new List<Collider2D>();
                for (int i = 0; i < 5; i++)
                {
                    GameObject newBullet = SpawnBullet();
                    bulletColliders.Add(newBullet.GetComponent<Collider2D>());
                }
                
                // Ignoră coliziunile între toate gloanțele de shotgun
                foreach (var bulletCollider1 in bulletColliders)
                {
                    foreach (var bulletCollider2 in bulletColliders)
                    {
                        if (bulletCollider1 != bulletCollider2)
                        {
                            Physics2D.IgnoreCollision(bulletCollider1, bulletCollider2);
                        }
                    }
                }
            }
            else
            {
                SpawnBullet();
            }
        }
    }

    private GameObject SpawnBullet()
    {
        GameObject instantiatedBullet = Instantiate(bullet, endpoints[index].position, endpoints[index].rotation);
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

        // Ignoră coliziunea între glonț și jucător
        Collider2D playerCollider = GetComponent<Collider2D>();
        if (playerCollider != null)
        {
            Physics2D.IgnoreCollision(playerCollider, instantiatedBullet.GetComponent<Collider2D>());
        }

        index = (index + 1) % endpoints.Length;

        return instantiatedBullet;
    }
}
