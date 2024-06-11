using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FutbolMovement : MonoBehaviour
{
    public float speed = 5f;
    public LayerMask groundLayer; // Capa que contiene los objetos "Ground"

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Obtener la entrada del teclado
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcular el vector de movimiento
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized * speed;

        // Comprobar si hay obstrucciones en la dirección de movimiento
        RaycastHit2D hit = Physics2D.Raycast(rb.position, movement, movement.magnitude * Time.deltaTime, groundLayer);

        // Si no hay obstrucciones, mover el objeto
        if (hit.collider == null)
        {
            rb.velocity = movement;
        }
        else
        {
            rb.velocity = Vector2.zero; // Detener el movimiento si hay colisión con un objeto "Ground"
        }
    }
}
