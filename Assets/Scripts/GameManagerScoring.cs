using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScoring : MonoBehaviour
{
    // Variable para almacenar el puntaje
    private static int score = 0;

    // Propiedad pública para acceder al puntaje
    public static int Score
    {
        get { return score; }
    }

    // Método para aumentar el puntaje
    public static void IncreaseScore(int amount)
    {
        score += amount;
    }

    // Método para reiniciar el puntaje
    public static void ResetScore()
    {
        score = 0;
    }

    // Método para guardar el puntaje entre escenas
    private void OnDisable()
    {
        PlayerPrefs.SetInt("Score", score);
    }

    // Método para cargar el puntaje al iniciar una nueva escena
    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
        }
        else
        {
            ResetScore();
        }
    }
}