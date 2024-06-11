using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransiciónEscena1 : MonoBehaviour
{

   
    [SerializeField] int numScene;
    public bool Restart = false;



    private void Update(){
        if(Restart == false){        
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z)){            
                SceneManager.LoadScene(numScene);           
            }   
        } else {
            if(Input.GetKeyDown(KeyCode.X)){            
                SceneManager.LoadScene(numScene);           
            }  
        }


    }


}
