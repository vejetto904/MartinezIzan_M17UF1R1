using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDeEnergia : MonoBehaviour
{
    private float velocidadX = 12.0f; 
    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }
    void Update()
    {
        Vector3 posicionActual = transform.position;
        posicionActual.x += velocidadX * Time.deltaTime;

        if (posicionActual.x >= 10.0f)
        {
            posicionActual.x = posicionInicial.x;
        }

        transform.position = posicionActual;
    }
}
