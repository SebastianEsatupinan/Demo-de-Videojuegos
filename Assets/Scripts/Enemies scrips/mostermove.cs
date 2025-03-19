using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float velocidad = 5.0f; // Velocidad de movimiento

    void Update()
    {
        // Mueve el objeto en su dirección actual
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

        // Mantén la rotación en el eje Y constante
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Cambia la dirección del objeto al colisionar con algo
        CambiarDireccion();
    }

    void CambiarDireccion()
    {
        // Genera una nueva dirección aleatoria en el plano XZ
        Vector3 nuevaDireccion = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;

        // Aplica la nueva dirección al objeto
        transform.forward = nuevaDireccion;

        // Mantén la rotación en el eje Y constante después de cambiar la dirección
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
