using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMoviendose : MonoBehaviour
{
    public float distancia = 5.0f; // Distancia que la plataforma se moverá de ida y vuelta.
    public float velocidad = 2.0f; // Velocidad a la que se moverá la plataforma.

    private Vector3 puntoInicial;
    private Vector3 puntoFinal;
    private bool yendoHaciaPuntoFinal = true;

    void Start()
    {
        puntoInicial = transform.position;
        puntoFinal = transform.position + Vector3.forward * distancia;
    }

    void Update()
    {
        // Calcula la nueva posición de la plataforma.
        Vector3 nuevaPosicion = yendoHaciaPuntoFinal ? puntoFinal : puntoInicial;

        // Mueve la plataforma hacia la nueva posición.
        transform.position = Vector3.MoveTowards(transform.position, nuevaPosicion, velocidad * Time.deltaTime);

        // Comprueba si la plataforma ha llegado a su destino y debe cambiar de dirección.
        if (Vector3.Distance(transform.position, nuevaPosicion) < 0.001f)
        {
            yendoHaciaPuntoFinal = !yendoHaciaPuntoFinal;
        }
    }
}
