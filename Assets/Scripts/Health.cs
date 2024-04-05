using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private BulletVelocity bulet;
    
    [SerializeField] private int health;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bulet != null)
        {
            health -= bulet.damage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    
    
}
