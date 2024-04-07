using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAI : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;


    [Header("Layer")]
    [SerializeField] private LayerMask groundLayer;

    [HideInInspector] public Vector3 spawnPosition;
    public GameObject portal;
    [SerializeField] private GameObject bloodParticles;


    private PlayerMovement player;
    private Vector3 target;

    

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        target = new Vector3(player.transform.position.x, transform.position.y, 0);
        Rotate();
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void Rotate()
    {
        if (target.x > transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(-5, 5, 5);
        }
        else if (target.x < transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(5, 5, 5);
        }
    }

    public void TakeDamage(int damage)
    {
        Instantiate(bloodParticles, transform.position, Quaternion.identity);
        currentHealth -= damage;
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public void Die()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int playerCoins = PlayerPrefs.GetInt("playerMoney");
            int stolenCoins = playerCoins / 2;

            Debug.Log("Coins stolen: " + stolenCoins);
            PlayerPrefs.SetInt("playerMoney", playerCoins - stolenCoins);

            Instantiate(portal, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.5f);

        }
    }
}
