using System.Collections.Generic;
using UnityEngine;

public class Entregas : MonoBehaviour
{
    public List<GameObject> puntosDeEntrega; // Asigna los cilindros desde el Inspector
    private GameObject puntoActual;

    void Start()
    {
        DesactivarTodos();
        ActivarNuevoPunto();
    }

    void DesactivarTodos()
    {
        foreach (GameObject punto in puntosDeEntrega)
        {
            punto.SetActive(false);
        }
    }

    void ActivarNuevoPunto()
    {
        if (puntosDeEntrega.Count == 0) return;

        List<GameObject> puntosDisponibles = new List<GameObject>(puntosDeEntrega);

        if (puntoActual != null)
            puntosDisponibles.Remove(puntoActual);

        if (puntosDisponibles.Count == 0) return;

        int index = Random.Range(0, puntosDisponibles.Count);
        puntoActual = puntosDisponibles[index];
        puntoActual.SetActive(true);
    }

    public void PuntoAlcanzado(GameObject punto)
    {
        if (punto == puntoActual)
        {
            puntoActual.SetActive(false);
            ActivarNuevoPunto();
        }
    }
}
