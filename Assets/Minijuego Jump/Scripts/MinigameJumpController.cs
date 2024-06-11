using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class MinigameJumpController : MonoBehaviour
{
    Vector2 checkpointPos;
    [SerializeField] int numScene;
    ContraReloj contraReloj;
    // Start is called before the first frame update
    void Start()
    {
        checkpointPos = transform.position;
        contraReloj = FindObjectOfType<ContraReloj>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle")){
            Die();
        }
        if(collision.CompareTag("Change")){
            ChangeScene();
        }
    }

    public void UpdateCheckPoint(Vector2 pos){
        checkpointPos = pos;
    }

    private void Die(){
        transform.position = checkpointPos;
    }
    private void ChangeScene(){


        SceneManager.LoadScene(numScene);
        // try
        // {
        //     float timer = contraReloj.ObtenerTiempo();

        //     switch (timer)
        //     {
        //         case float n when n <= 35f:
        //             SceneManager.LoadScene(17); 
        //             break;
        //         case float n when n > 35f && n < 60f:
        //             SceneManager.LoadScene(18); 
        //             break;
        //         case float n when n >= 60f:
        //             SceneManager.LoadScene(19); 
        //             break;
        //         default:
        //             SceneManager.LoadScene(numScene); // Cargar una escena por defecto si el temporizador no se encuentra en ninguno de los rangos especificados
        //             break;
        //     }
        // }
        // catch (NullReferenceException e)
        // {
        //     Debug.Log("Se produjo una excepción de puntero nulo al obtener el temporizador: " + e.Message);
        //     SceneManager.LoadScene(numScene); // Cargar una escena por defecto en caso de excepción de puntero nulo
        // }
    }

    
}
