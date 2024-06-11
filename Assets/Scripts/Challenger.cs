using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenger : MonoBehaviour,Interactable 
{
    [SerializeField] Dialog dialog;
    private bool isDialogActive = false; 
    public static bool isSceneChangeAllowed = false; 
    [SerializeField] string nameScence;

    public int score; 

    public void Interact(){
        if (isDialogActive) // Verificar si el diálogo está activo

        {

            if (isSceneChangeAllowed) // Verificar si se permite el cambio de escena
            {       
                    ScoreManager.Instance.AddScore(score);
                    UnityEngine.SceneManagement.SceneManager.LoadScene(nameScence);
            }
            else
            {
                    DialogManager.Instance.HandleUpdate(); 
            }
        
        }
        else
        {
            isDialogActive = true;
            StartCoroutine(DialogManager.Instance.ShowDialog(dialog, null));
        }
    } 




}
