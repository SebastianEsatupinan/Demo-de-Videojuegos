using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    public Transform objetivo; // El objeto que la c�mara debe seguir (el personaje).
    public float distancia = 5f; // Distancia entre la c�mara y el personaje.
    public float altura = 2f; // Altura de la c�mara sobre el personaje.

    private void FixedUpdate()
    {
        if (objetivo != null)
        {
            // Calcula la posici�n objetivo de la c�mara.
            Vector3 direccionAtras = -objetivo.forward;
            Vector3 posicionObjetivo = objetivo.position + direccionAtras * distancia + Vector3.up * altura;

            // Aplica suavizado al movimiento de la c�mara.
            transform.position = Vector3.Lerp(transform.position, posicionObjetivo, Time.deltaTime * 5);
            transform.LookAt(objetivo);
        }
    }
}
