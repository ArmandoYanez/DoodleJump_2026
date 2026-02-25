using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Player : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites; // 0: Salto, 1: Caída, 2: Muerte
    public AudioSource audio;
    private Rigidbody2D rb;
    private bool estaVivo = true;

    [Header("Sistema de Puntos")]
    public int puntos = 0;
    private float alturaMaxima = 0f;
    public float limiteCaida = 10f;
    public TextMeshProUGUI text;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer.sprite = sprites[0];
        alturaMaxima = transform.position.y;
    }

    void Update()
    {
        
        if (!estaVivo) return; // Si murió, no hace nada más
        text.text = puntos.ToString("00");
        MoveRight();
        MoveLeft();
        ActualizarPuntaje();
        GestionarSprites();
        RevisarSiPerdio();
    }

    void GestionarSprites()
    {
        // Si va hacia arriba, sprite de salto
        if (rb.linearVelocity.y > 0.1f)
        {
            spriteRenderer.sprite = sprites[0];
        }
        // Si va hacia abajo, sprite de caída
        else if (rb.linearVelocity.y < -0.1f)
        {
            spriteRenderer.sprite = sprites[1];
        }
    }

    void ActualizarPuntaje()
    {
        if (transform.position.y > alturaMaxima)
        {
            alturaMaxima = transform.position.y;
            puntos = Mathf.RoundToInt(alturaMaxima * 10);
        }
    }

    void RevisarSiPerdio()
    {
        if (transform.position.y < (alturaMaxima - limiteCaida))
        {
            Morir();
        }
    }

    void Morir()
    {
        estaVivo = false;
        spriteRenderer.sprite = sprites[2]; // Sprite de muerte
        Debug.Log("¡PERDISTE! Puntuación final: " + puntos);
        
        // Opcional: darle un pequeño impulso hacia arriba al morir
        rb.linearVelocity = new Vector2(0, 5f);
        // Desactivar el collider para que caiga al vacío
        GetComponent<Collider2D>().enabled = false;
    }

    public void MoveRight()
    {
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * 5f * Time.deltaTime);
            spriteRenderer.flipX = false; 
        }
    }

    public void MoveLeft()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * 5f * Time.deltaTime);
            spriteRenderer.flipX = true; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!estaVivo) return;

        // Si colisiona por arriba (cayendo)
        if (rb.linearVelocity.y <= 0.1f)
        {
            if (collision.gameObject.CompareTag("Plataforma"))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 9f); 
                audio.Play();
            }
            else if (collision.gameObject.CompareTag("Speed_Plataforma"))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 15f); 
                audio.Play();
            }
            else if (collision.gameObject.CompareTag("Danger_Plataforma"))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 9f); 
                collision.gameObject.GetComponent<Danger_Plataform>().startBreaking();
                audio.Play();
            }
        }
    }
}