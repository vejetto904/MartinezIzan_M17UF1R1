using System.Collections;
using UnityEngine;

public class ControlPersonaje : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    private Animator animador;
    private bool gravedadInvertida = false;

    void Start()
    {
        animador = GetComponent<Animator>();
    }

    void Update()
    {
        MoverPersonaje();
        InvertirGravedad();
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
        }

        // Mover el personaje en la dirección correcta
        transform.Translate(movimiento * velocidadMovimiento * Time.deltaTime * (gravedadInvertida ? -1 : 1));
    }

    void InvertirGravedad()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gravedadInvertida = !gravedadInvertida;
            Physics2D.gravity = new Vector2(0, gravedadInvertida ? -9.8f : 9.8f);
            transform.Rotate(0, 0, 180 * (gravedadInvertida ? -1 : 1)); // Gira el personaje 180 grados en el eje Z
        }
    }

    void ActualizarAnimacion()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        animador.SetBool("IsRunning", Mathf.Abs(movimientoHorizontal) > 0.1f);
    }
}