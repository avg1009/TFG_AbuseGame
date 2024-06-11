using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementMiniGame : MonoBehaviour
{   //--------------------------------------------WASD--------------------------------------------------------------------
    [SerializeField]public float moveSpeed = 5f;
    [SerializeField]public float fuerzaSalto = 10f;

    public float gravedad = 20f;

    public bool isAutomaticMovementHor = false;
    public bool needMovementVertical = false;


    private Rigidbody2D rb;
    public bool enSuelo;



    private bool isMoving;

    public Vector2 input;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    //  input.y = Input.GetAxisRaw("Vertical");
    private void Update()
    {
        switch(isAutomaticMovementHor==false){
            case true:
                AutoHorizontal();
                break;
            case false when needMovementVertical == true:
                movimientoHorizontalYVerticalSinSalto();
                break;

            default:
                movimientoHorizontalYSalto();
                break;


        }


    }
    

    private void movimientoHorizontalYVerticalSinSalto(){
        // float velocidadVertical= moveSpeed;

        // float movimientoHorizontal = Input.GetAxis("Horizontal");
        // float movimientoVertical = Input.GetAxis("Verical");

        // Vector2 movimiento = new Vector2(movimientoHorizontal * moveSpeed, rb.velocity.y);
        // rb.velocity = movimiento;


        
        if (!isMoving){
            input.x = Input.GetAxis("Horizontal");// * Sensitivity;
            input.y = Input.GetAxis("Vertical");// * Sensitivity;
            if(input != Vector2.zero){
                var targetPos = transform.position;
                targetPos.x += input.x; 
                targetPos.y += input.y;
                
                StartCoroutine(Move(targetPos));
            }

            if(input.x != 0) input.y= 0;
        }
    }

        

     
    private void Salto(){
                // Salto
        if (enSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
        }

    }

    private void movimientoHorizontalYSalto(){
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        Vector2 movimiento = new Vector2(movimientoHorizontal * moveSpeed, rb.velocity.y);
        rb.velocity = movimiento;

        Salto();


    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            enSuelo = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            enSuelo = false;
        }
    }

    private void FixedUpdate()
    {
        // Aplicar gravedad
        rb.AddForce(Vector2.down * gravedad);
    }


    private void AutoHorizontal(){
            Vector2 movimiento = new Vector2( moveSpeed, rb.velocity.y);
            rb.velocity = movimiento;
            Salto();
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
}
