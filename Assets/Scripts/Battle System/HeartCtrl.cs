using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCtrl : MonoBehaviour
{
    private Vector3 StartingPos = Vector3.zero; 

    public float moveSpeed;
    private bool isMoving;

    //public float Sensitivity;
    private Vector2 input;

    /*public int MaxX = 2;
    public int MaxY = 3;
    public int MinX = -3;
    public int MinY = -2;*/


    public LayerMask solidObjectsLayer; 


    public LayerMask interactablesLayer;

    void Start(){
        SetHeart();
    }
    public void SetHeart(){
        //transform.position = StartingPos;
        //input = StartingPos;
    }

    void FixedUpdate(){
        if (!isMoving){
            input.x = Input.GetAxis("Horizontal");// * Sensitivity;
            input.y = Input.GetAxis("Vertical");// * Sensitivity;
            if(input != Vector2.zero){
                var targetPos = transform.position;
                targetPos.x += input.x; 
                targetPos.y += input.y;
                if(isWalkable(targetPos)){
                    StartCoroutine(Move(targetPos));}
            }
           // input.x += horizontal;
           // input.y += vertical;

            //input.x += Mathf.Clamp(input.x , MinX, MaxX);
            //input.y += Mathf.Clamp(input.y , MinY, MaxY);

            //transform.position = Vector2.Lerp(transform.position, input, moveSpeed * Time.deltaTime);
        }
    }
    IEnumerator Move(Vector3 targetPos){
        isMoving = true; 

        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon){
            transform.position = Vector3.MoveTowards(transform.position, targetPos , moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
    }

    private bool isWalkable(Vector3 targetPos){
        if( Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer | interactablesLayer ) != null) {return false;}
        return true;
    }    
    
}
