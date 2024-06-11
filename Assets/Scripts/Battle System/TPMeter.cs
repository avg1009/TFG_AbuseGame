using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPMeter : MonoBehaviour
{
    public Color ActiveCol;
    public Color PassiveCol;
    private Color Col;

    private float ColLerp;

    private SpriteRenderer Sprt;

    public float TPAmt;

    void Start(){
        ColLerp = 0;
        TPAmt = 0;
        Sprt= GetComponent<SpriteRenderer>();

    }

    void Update(){
        Col = Color.Lerp(PassiveCol, ActiveCol , ColLerp);

        Sprt.color = Col;

        if(ColLerp > 0 ){
            ColLerp -= Time.deltaTime;
        }
    }

    private void onTriggerEnter2D(Collider2D other){
        ColLerp = 1 ; 
        if(TPAmt < 100){
            TPAmt += 0.1f; 
        }
    }
}
