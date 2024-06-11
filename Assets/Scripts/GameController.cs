using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState{ Free, Dialog, Battle}
public class GameController : MonoBehaviour
{
    //TO DO Scoring

    [SerializeField] Controller controller;

    GameState state;

    public void Start(){

        DialogManager.Instance.OnShowDialog += () => {
            state = GameState.Dialog;
        };

        DialogManager.Instance.OnHideDialog += () => {
            if ( state == GameState.Dialog){

                state = GameState.Free;
            }
            
        };
    }

    private void Update(){

        if(state == GameState.Free){
            controller.HandleUpdate();
        } else if ( state == GameState.Dialog){

            DialogManager.Instance.HandleUpdate();
            
        } else if( state == GameState.Battle){

        }


    }

}
