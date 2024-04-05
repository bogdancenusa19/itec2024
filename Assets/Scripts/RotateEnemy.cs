using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEnemy : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform enemyTransform;

    private void Update()
    {
        if (playerTransform.position.x > enemyTransform.position.x)
        {
            gameObject.transform.localScale = new Vector3(-5, 5, 5);
        }
        else if (playerTransform.position.x < enemyTransform.position.x)
        {
            gameObject.transform.localScale = new Vector3(5, 5, 5);
        }
    }
}
