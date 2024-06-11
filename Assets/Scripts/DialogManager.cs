using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox; 
    [SerializeField] Text dialogText;

    [SerializeField] int lettersPerSecond;

    public event Action OnShowDialog;
    public event Action OnHideDialog;


    public static DialogManager Instance { get; private set; }

    public void Awake(){
        Instance = this; 
    }


    public IEnumerator ShowDialog(Dialog dialog){

        yield return new WaitForEndOfFrame();
        OnShowDialog?.Invoke();

        this.dialog = dialog;
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));
    }


    public IEnumerator ShowDialog(Dialog dialog, string sceneName){
        yield return new WaitForEndOfFrame();
        OnShowDialog?.Invoke();

        this.dialog = dialog;
        dialogBox.SetActive(true);
        for (int i = 0; i < dialog.Lines.Count; i++)
        {
            yield return StartCoroutine(TypeDialog(dialog.Lines[i]));
        }
        
        dialogBox.SetActive(false);
        OnHideDialog?.Invoke();

        if (sceneName != null) // Verificar si se debe cambiar de escena
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }


    Dialog dialog;
    int currentLine = 0;
    bool isTyping;

   public void HandleUpdate(){

        /*if (Input.GetKeyDown(KeyCode.Z) && !isTyping){ 

            ++currentLine; 

            if(currentLine < dialog.Lines.Count){

                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
            }else {

                dialogBox.SetActive(false);
                currentLine = 0;
                OnHideDialog?.Invoke();
            }

        }*/

        if (isTyping) // Verificar si se está escribiendo el diálogo
        {
            // Permitir al jugador omitir la escritura del diálogo
            StopAllCoroutines();
            dialogText.text = dialog.Lines[currentLine];
            isTyping = false;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (currentLine < dialog.Lines.Count - 1) // Verificar si hay más líneas de diálogo
                {
                    currentLine++;
                    StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
                }
                else
                {
                    dialogBox.SetActive(false);
                    currentLine = 0;
                    OnHideDialog?.Invoke();
                    Challenger.isSceneChangeAllowed = true; // Permitir el cambio de escena al finalizar el diálogo
                }
            }
        }

    }


    public IEnumerator TypeDialog( string line){
        isTyping = true; 
        dialogText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter; 
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        isTyping = false;
    }

}
