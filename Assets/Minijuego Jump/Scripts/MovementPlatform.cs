// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class MovementPlatform : MonoBehaviour
// {
//     [SerializeField]public Transform posA,posB;
//     public float speed;
//     Vector3 targetpos;
//     public bool rotateposB = false;

//     private void Start(){

//         targetpos = posB.position;

//     }


//     private void Update(){
//         if(Vector2.Distance(transform.position, posA.position)<0.05f){
//             targetpos = posB.position;
//         }
//         if(Vector2.Distance(transform.position, posB.position)<0.05f){
//             targetpos = posA.position;
//         }

//         transform.position = Vector3.MoveTowards (transform.position, targetpos, speed * Time.deltaTime);
//     }

//     private void Rotate(){
        
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlatform : MonoBehaviour
{
    [SerializeField] public Transform posA, posB;
    public float speed;
    Vector3 targetpos;
    public bool rotateposB = false;

    private void Start()
    {
        targetpos = posB.position;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < 0.50f)
        {
            targetpos = posB.position;
            if(rotateposB == true){
                transform.Rotate(0,0,360);} // Rotar a 360 cuando alcanza posA
        }
        if (Vector2.Distance(transform.position, posB.position) < 0.50f)
        {
            targetpos = posA.position;
            if(rotateposB == true){
                transform.Rotate(0,0,180);} // Rotar a 180 cuando alcanza posB
        }

        transform.position = Vector3.MoveTowards(transform.position, targetpos, speed * Time.deltaTime);
    }

}
