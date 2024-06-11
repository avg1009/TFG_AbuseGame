using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransiciónEscena : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private AnimationClip animationFinal;
   
    [SerializeField] string nameScence;
    [SerializeField] int numScene;

    private void Start(){

        animator= GetComponent<Animator>();

    }

    private void Update(){
        
        if(Input.GetKeyDown(KeyCode.Space) &&  SceneManager.GetActiveScene().buildIndex == 0){            
            StartCoroutine(ChangeScence());            
        }

    }
    //COroutine
    IEnumerator ChangeScence(){
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(animationFinal.length);
        SceneManager.LoadScene(numScene);
    }
}
