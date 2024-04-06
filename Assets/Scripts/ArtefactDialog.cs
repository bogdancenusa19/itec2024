using UnityEngine;
using UnityEngine.SceneManagement; // Acest namespace este necesar pentru a lucra cu scene

public class ArtefactDialog : MonoBehaviour
{
    public GameObject dialogBox; // Referință la caseta de dialog UI
    private bool playerIsInZone = false; // Stare pentru a ține evidența dacă jucătorul este în zonă

    private void Update()
    {
        // Verifică dacă jucătorul este în zonă și apasă pe tasta "T"
        if (playerIsInZone && Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene(0); // Încarcă scena cu indexul 0
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogBox.SetActive(true);
            playerIsInZone = true; // Jucătorul a intrat în zonă
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogBox.SetActive(false);
            playerIsInZone = false; // Jucătorul a ieșit din zonă
        }
    }
}