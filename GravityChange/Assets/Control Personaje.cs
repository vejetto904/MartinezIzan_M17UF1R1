using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class ControlPersonaje : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
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
            rb.gravityScale = (gravedadInvertida) ? -1 : 1;

            // Obtener el componente SpriteRenderer
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            // Voltear el sprite verticalmente
            spriteRenderer.flipY = gravedadInvertida;
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NextLevel"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (collision.gameObject.CompareTag("ReturnLevel"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if (collision.gameObject.CompareTag("Pinchos"))
        {
            // El jugador ha tocado los pinchos, reinicia la escena
            SceneManager.LoadScene(0);
        }
    }

}