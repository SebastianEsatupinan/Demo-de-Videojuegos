using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiuzaPlataformasMovimiento : MonoBehaviour
{
    public float distanciaTotal = 5.0f; // Distancia total que se moverá el objeto
    public float velocidad = 2.0f; // Velocidad de movimiento del objeto

    private Vector3 puntoInicial;
    private Vector3 puntoFinal;
    private bool moviendoseHaciaZPositivo = true;

    void Start()
    {
        puntoInicial = transform.position;
        puntoFinal = puntoInicial + Vector3.forward * distanciaTotal; // Usamos Vector3.forward en lugar de Vector3.right
    }

    void Update()
    {
        if (moviendoseHaciaZPositivo)
        {
            MoverObjeto(puntoFinal);
        }
        else
        {
            MoverObjeto(puntoInicial);
        }
    }

    void MoverObjeto(Vector3 destino)
    {
        float paso = velocidad * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, destino, paso);

        if (transform.position == destino)
        {
            moviendoseHaciaZPositivo = !moviendoseHaciaZPositivo;
        }
    }
}
