using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    private int score;
    public Text textScore;

    void Start()
    {
        // Inicializar el score con el valor del ScoreManager
        if (ScoreManager.Instance != null)
        {
            score = ScoreManager.Instance.Score;
        }
    }

    void Update()
    {
        if (ScoreManager.Instance != null)
        {
            // Mantener el score actualizado con el valor del ScoreManager
            score = ScoreManager.Instance.Score;
            textScore.text = "Marcador: " + score.ToString();
        }
    }
}
