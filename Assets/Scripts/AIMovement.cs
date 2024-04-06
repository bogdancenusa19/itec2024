using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float chaseDistance;
    [SerializeField] private float rangeDistance;

    private Animator animator;
    private PlayerMovement player;
    private float distance;

    private bool isPlayerInRange = true;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= rangeDistance)
        {
            if (distance >= chaseDistance)
            {
                animator.SetBool("isRunning", true);
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                isPlayerInRange = true;
            }
        }
        else if (distance > chaseDistance)
        {
            isPlayerInRange = false;
            animator.SetBool("isRunning", false);
        }
    }

    public bool CanShootPlayer()
    {
        return isPlayerInRange;
    }
}
