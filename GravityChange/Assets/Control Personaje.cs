using System.Collections;
using UnityEngine;
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
            Debug.Log(movimientoHorizontal);
        }

        // Mover el personaje en la dirección correcta
        transform.Translate(movimiento * velocidadMovimiento * Time.deltaTime);
    }

    void InvertirGravedad()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gravedadInvertida = !gravedadInvertida;
            if (gravedadInvertida == true) rb.gravityScale = -1;
            else rb.gravityScale = 1;
            // Obtener el componente SpriteRenderer
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            // Voltear el sprite verticalmente
            spriteRenderer.flipY = true;
            if (gravedadInvertida == true) spriteRenderer.flipY = true;
            else spriteRenderer.flipY = false;
        }      
    }

    void ActualizarAnimacion()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        animador.SetBool("IsRunning", Mathf.Abs(movimientoHorizontal) > 0.1f);
    }
}