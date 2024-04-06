using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float chaseDistance;
    [SerializeField] private float rangeDistance;

    [Header("Objects")]
    public Transform groundCheck;

    [Header("Layer")]
    [SerializeField] private LayerMask groundLayer;

    private Animator animator;
    private PlayerMovement player;
    private float distance;

    private bool isPlayerInRange = false;
    private bool canMove = true;

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
            if (canMove)
            {
                if (distance >= chaseDistance)
                {
                    animator.SetBool("isRunning", true);
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                    isPlayerInRange = true;
                }
                else
                {
                    animator.SetBool("isRunning", false);

                }
            } 
            else
            {
                animator.SetBool("isRunning", false);
                if(distance >= chaseDistance)
                {
                    isPlayerInRange = true;
                }
            }
        }
        else if (distance > chaseDistance)
        {
            isPlayerInRange = false;
            animator.SetBool("isRunning", false);
        }
    }

    public void SetMove(bool value)
    {
        canMove = value;
    }

    public void SetPlayerInRange(bool value)
    {
        isPlayerInRange = value;
        animator.SetBool("isRunning", value);
    }

    public bool CanShootPlayer()
    {   
        if (player != null && isPlayerInRange)
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, chaseDistance);

    }
}
