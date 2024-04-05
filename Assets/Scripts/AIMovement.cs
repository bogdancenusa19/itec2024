using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float chaseDistance;
    [SerializeField] private float rangeDistance;
    private float distance;

    private bool isPlayerInRange = true;
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= rangeDistance)
        {
            if (distance >= chaseDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                isPlayerInRange = true;
            }
        }
        else if (distance > chaseDistance)
        {
            isPlayerInRange = false;
        }
    }

    public bool CanShootPlayer()
    {
        return isPlayerInRange;
    }
}
