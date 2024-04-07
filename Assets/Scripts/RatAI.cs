using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAI : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float speed;

    [Header("Layer")]
    [SerializeField] private LayerMask groundLayer;

    public Vector3 spawnPosition;

    private PlayerMovement player;
    private float distance;
    private bool coinsStolen;
    private Vector3 target;

    

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Move();
    }

    private void Move()
    {
        if (!coinsStolen)
        {
            // go towards the player
            target = new Vector3(player.transform.position.x, transform.position.y, 0);
        }
        else
        {
            target = new Vector3(spawnPosition.x, transform.position.y, 0);
        }
  
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

    }

    private void Rotate()
    {
        if (player.transform.position.x > transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(-5, 5, 5);
        }
        else if (player.transform.position.x < transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(5, 5, 5);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int playerCoins = PlayerPrefs.GetInt("playerMoney");
            int stolenCoins = playerCoins / 2;

            coinsStolen = true;
        }
    }

    public bool MoneyIsStolen()
    {
        return coinsStolen;
    }
}
