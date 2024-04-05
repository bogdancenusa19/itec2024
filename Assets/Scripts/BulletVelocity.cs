using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVelocity : MonoBehaviour
{
    private float bulletSpeed = 15f;
    private float scaleToShoot = 0;

    private Rigidbody2D bulletRb;
    
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
        Debug.Log(scaleToShoot);
    }
    
    void FixedUpdate()
    {
        bulletRb.velocity = new Vector2(bulletSpeed * scaleToShoot, 0f);
    }

    public void GetCorrectScale(GameObject parent)
    {
        scaleToShoot = -parent.transform.localScale.x;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
