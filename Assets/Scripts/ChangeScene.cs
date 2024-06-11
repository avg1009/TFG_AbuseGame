using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour,Interactable 
{


    [SerializeField] int numScence;

    public void Interact(){

            SceneManager.LoadScene(numScence);
    } 

}
