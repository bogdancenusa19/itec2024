using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Încarcă din nou scena curentă
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}