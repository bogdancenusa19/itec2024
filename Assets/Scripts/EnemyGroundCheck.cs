using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundCheck : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    private void OnTriggerExit2D(Collider2D collision)
    {
        // stop movement
        //enemy.GetComponent<AIMovement>().SetPlayerInRange(false);
        enemy.GetComponent<AIMovement>().SetMove(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemy.GetComponent<AIMovement>().SetMove(true);
    }

}
