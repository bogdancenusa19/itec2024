using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSpawner : MonoBehaviour
{
    public GameObject spawner;
    public GameObject spawnPoint;
    public GameObject rat;
    public float timeToSpawn;


    private bool startTimer = false;

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
        spawner.SetActive(true);
        yield return new WaitForSeconds(timeToSpawn - 0.6f);
        SpawnRat();
        yield return new WaitForSeconds(timeToSpawn);
        Destroy(gameObject, 0.5f);
    }

    private void SpawnRat()
    {
        GameObject ratAI = Instantiate(rat, spawnPoint.transform.position, Quaternion.identity);
        ratAI.GetComponent<RatAI>().spawnPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            startTimer = true;
        }
    }
}
