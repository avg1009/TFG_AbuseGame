using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContraReloj : MonoBehaviour
{
    public float timer = 0;
    public Text textTimer;

    void Update()
    {
        timer += Time.deltaTime;
        textTimer.text = "" + timer.ToString("f1") + " seg";
    }

    // Método público para obtener el valor del temporizador
    public float ObtenerTiempo()
    {
        return timer;
    }
}
