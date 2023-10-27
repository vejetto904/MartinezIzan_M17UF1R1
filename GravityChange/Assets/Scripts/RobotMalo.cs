using System.Collections;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public float puntoInicioX;
    public float puntoFinalX;
    public float velocidad = 5.0f;
    public float tiempoEsperaEnPuntoFinal = 1.0f;

    private Vector3 puntoInicio;
    private Vector3 puntoFinal;
    private bool mirandoDerecha = true;
    private SpriteRenderer spriteRenderer;

    private AudioSource Musica;
    void Start()
    {
        puntoInicio = new Vector3(puntoInicioX, transform.position.y, transform.position.z);
        puntoFinal = new Vector3(puntoFinalX, transform.position.y, transform.position.z);
        spriteRenderer = GetComponent<SpriteRenderer>();
        Musica = GetComponent<AudioSource>();


        StartCoroutine(MoverEnemigo());
    }

    IEnumerator MoverEnemigo()
    {
        while (true)
        {
            // Mover hacia el punto final
            while (Mathf.Abs(transform.position.x - puntoFinal.x) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, puntoFinal, velocidad * Time.deltaTime);
                MirarDireccion(puntoFinal);
                yield return null;
            }

            // Esperar en el punto final
            yield return new WaitForSeconds(tiempoEsperaEnPuntoFinal);
            Musica.Play();

            // Mover hacia el punto de inicio
            while (Mathf.Abs(transform.position.x - puntoInicio.x) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, puntoInicio, velocidad * Time.deltaTime);
                MirarDireccion(puntoInicio);
                yield return null;
            }
        }
    }

    void MirarDireccion(Vector3 targetPosition)
    {
        if (targetPosition.x > transform.position.x && !mirandoDerecha)
        {
            // Mover a la derecha
            mirandoDerecha = true;
            spriteRenderer.flipX = false;
        }
        else if (targetPosition.x < transform.position.x && mirandoDerecha)
        {
            // Mover a la izquierda
            mirandoDerecha = false;
            spriteRenderer.flipX = true;
        }
    }
}