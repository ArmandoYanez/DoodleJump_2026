using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer.sprite = sprites[0]; // Asigna el primer sprite al inicio
    }

    // Update is called once per frame
    void Update()
    {
        // Funcion para movimiento derecha 
        MoveRight();
    }
    
    public void MoveRight()
    {
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * 5f * Time.deltaTime);
        }
    }

    public void MoveLeft()
    {
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * 5f * Time.deltaTime);
        }
    }

    // Colision con la plataforma para saltar 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            // Usamos un margen pequeño (0.1) para asegurar que estamos cayendo
            if (GetComponent<Rigidbody2D>().linearVelocity.y <= 0.1f)
            {
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                // Reset de velocidad en Y antes de aplicar el salto para que siempre sea igual
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 7f); 
            }
        }
    }
    
}
