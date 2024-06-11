using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementControllerMinigameJump : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] int speed;
    [Range(1,10)]
    [SerializeField] float acceleration;


    float speedMultiplier;
    bool btnPressed;

    bool isWallTouch;
    [SerializeField] public LayerMask wallLayer;
    [SerializeField] public Transform wallCheckPoint;
    Vector2 relativeTransform ;


    private void Start(){
        UpdateRelativeTransform();
    }

    private void Awake(){

        rb = GetComponent<Rigidbody2D>();


    }
    private void FixedUpdate(){

        UpdateSpeedMultiplier();
        float targetSpeed = speed * speedMultiplier*relativeTransform.x;
        rb.velocity = new Vector2(targetSpeed,rb.velocity.y);

        isWallTouch = Physics2D.OverlapBox(wallCheckPoint.position,new Vector2(0.16f, 1.4f),0,wallLayer);
        if(isWallTouch){ Flip();}
    }
    public void Flip()
    {
        transform.Rotate(0,180,0);
        UpdateRelativeTransform();
    }

    void UpdateRelativeTransform(){
        relativeTransform = transform.InverseTransformVector(Vector2.one);
    }

    public void Move(InputAction.CallbackContext value)
    {
        if(value.started)
        {
            btnPressed = true;
            speedMultiplier = 1;

        }else if(value.canceled){
            btnPressed = false;
            speedMultiplier = 0;
        }
    }
    void UpdateSpeedMultiplier(){
        if(btnPressed && speedMultiplier < 1 ){
            speedMultiplier+= Time.deltaTime*acceleration ;
        }
        else if(!btnPressed && speedMultiplier > 0){
            speedMultiplier -= Time.deltaTime*acceleration;
            if(speedMultiplier < 0) speedMultiplier = 0 ;
        }
    }
}
