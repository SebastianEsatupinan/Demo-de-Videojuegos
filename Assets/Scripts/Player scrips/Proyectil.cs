using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Si el objeto colisionado tiene el tag "Enemigos"
        if (collision.gameObject.CompareTag("Enemigos"))
        {
            // Destruir el proyectil y el enemigo
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}