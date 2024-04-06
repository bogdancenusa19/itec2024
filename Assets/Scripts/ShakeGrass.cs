using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeGrass : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            animator.SetTrigger("touched");
        }
    }
}
