
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextManager textManager;
    private readonly float restartTime = 3; 

    private void Start()
    {
        textManager = FindObjectOfType<TextManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            textManager.DisplayCustomMessage("Game over! Restarting...", restartTime-0.5f);
            Invoke(nameof(RestartScene), restartTime); 
        }
    }

    private void RestartScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

