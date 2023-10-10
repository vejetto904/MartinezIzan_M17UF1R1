using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class ControlPersonaje : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    private float velocidadVertical = 7f;
    private Animator animador;
    private bool gravedadInvertida = false;
    private Rigidbody2D rb;

    void Start()
    {
        animador = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoverPersonaje();
        if (rb.velocity.y == 0)
        {
            InvertirGravedad();
        }
        ActualizarAnimacion();
        ReiniciarNivel();
    }

    void MoverPersonaje()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        Vector2 movimiento = new Vector2(movimientoHorizontal, 0);

        // Obtener el componente SpriteRenderer
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (movimientoHorizontal != 0)
        {
            // Si el personaje se está moviendo, ajusta la orientación del sprite
            spriteRenderer.flipX = (movimientoHorizontal < 0);
        }

        // Mover el personaje en la dirección correcta
        transform.Translate(movimiento * velocidadMovimiento * Time.deltaTime);
    }

    void InvertirGravedad()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gravedadInvertida = !gravedadInvertida;
            //rb.gravityScale = (gravedadInvertida) ? -1 : 1;

            // Obtener el componente SpriteRenderer
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            // Voltear el sprite verticalmente
            spriteRenderer.flipY = gravedadInvertida;

            Vector2 nuevaVelocidad = rb.velocity;
            nuevaVelocidad.y = velocidadVertical * -1;
            rb.velocity = nuevaVelocidad;

            // Ajustar la velocidad vertical solo cuando se invierte la gravedad
            if (gravedadInvertida)
            {               
                nuevaVelocidad.y = velocidadVertical * 1;
                rb.velocity = nuevaVelocidad;
            }
            else
            {
                nuevaVelocidad.y = velocidadVertical * -1;
                rb.velocity = nuevaVelocidad;
            }
        }
    }

    void ActualizarAnimacion()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        animador.SetBool("IsRunning", Mathf.Abs(movimientoHorizontal) > 0.1f);
    }

    void ReiniciarNivel()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Obtener el índice de la escena actual
            int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;

            // Recargar la escena actual
            SceneManager.LoadScene(indiceEscenaActual);
        }
    }

}