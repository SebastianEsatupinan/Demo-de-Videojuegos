using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionArrow : MonoBehaviour
{
    public Transform target;  // El objeto o punto hacia donde la flecha debe apuntar

    void Update()
    {
        // Hacer que la flecha apunte hacia el objetivo
        Vector3 direction = target.position - transform.position; // Calcular dirección
        Quaternion rotation = Quaternion.LookRotation(direction);  // Obtener la rotación
        transform.rotation = rotation;  // Aplicar la rotación a la flecha
    }
}
