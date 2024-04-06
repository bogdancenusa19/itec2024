using UnityEngine;

public class PauseMenu1 : MonoBehaviour
{
    public GameObject pauseMenuUI; // Referință la UI-ul de pauză

    private bool isPaused = false; // Stare pauză

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Reia timpul jocului
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Oprește timpul jocului
        isPaused = true;
    }
    
    public void RestartGame()
    {
        Debug.Log("Restart!");
        Time.timeScale = 1f; // Reia timpul jocului
        Application.LoadLevel(Application.loadedLevel); // Reîncarcă scena curentă
    }
    
    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
        Time.timeScale = 1f; // Reia timpul jocului
        Application.LoadLevel(0); // Încarcă scena cu indexul 0
    }

    // Funcția de Quit poate fi apelată de un buton din meniul de pauză
    public void QuitGame()
    {
        Debug.Log("Quit!");
        // iesim din joc
        Application.Quit();
    }
}