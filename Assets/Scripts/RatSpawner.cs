using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSpawner : MonoBehaviour
{
    public GameObject spawner;
    public GameObject rat;
    public float timeToSpawn;


    private bool startTimer = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            StartCoroutine(SpawnRat(timeToSpawn));
            startTimer = false;
        }

        
    }

    IEnumerator SpawnRat(float timeToSpawn)
    {
        yield return new WaitForSeconds(timeToSpawn);
        SpawnRat();
    }

    private void SpawnRat()
    {
        GameObject ratAI = Instantiate(rat, spawner.transform.position, Quaternion.identity);
        ratAI.GetComponent<RatAI>().spawnPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            startTimer = true;
            CircleCollider2D collider = GetComponent<CircleCollider2D>();
        }

        if (collision.CompareTag("Rat"))
        {
            RatAI ratAI = collision.GetComponent<RatAI>();
            if (ratAI.MoneyIsStolen())
            {
                Destroy(gameObject);
            }
        }
    }
}
