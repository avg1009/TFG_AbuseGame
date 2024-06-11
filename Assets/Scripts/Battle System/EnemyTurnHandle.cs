using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnHandle : MonoBehaviour
{
    public bool FinishedTurn;

    public int AttakAmounts;

    private void Start(){

        FinishedTurn = false;

        int AtkNumb = Random.Range(0, AttakAmounts);
        GetComponent<Animator>().SetInteger("AtkDex", AtkNumb);
    }

    private void AtkDone(){
        FinishedTurn = true;
    }
}
