using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class muerteJugador : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto que colisionó es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reinicia la escena
            Reiniciar();
        }
    }

    void Reiniciar()
    {
        // Obtiene el nombre de la escena actual
        string nombreEscenaActual = SceneManager.GetActiveScene().name;

        // Recarga la escena actual
        SceneManager.LoadScene(nombreEscenaActual);
    }
}
