using UnityEngine;
using UnityEngine.UI;

public class ArrowGuide : MonoBehaviour
{
    public Transform[] points;   // Los 3 puntos del mapa a los que el personaje debe dirigirse
    public Image arrowImage;     // La flecha en la UI
    public float rotationSpeed = 5f; // Velocidad de rotación de la flecha
    private Transform targetPoint;   // El punto al que el personaje se dirigirá
    private int currentTargetIndex = 0; // El índice del punto actual

    void Start()
    {
        // Inicializamos con el primer punto
        SetTargetPoint(currentTargetIndex);
    }

    void Update()
    {
        // Asegurarse de que siempre haya un punto de destino asignado
        if (targetPoint != null)
        {
            // Calcula la dirección desde la flecha hacia el punto de destino
            Vector3 directionToTarget = targetPoint.position - arrowImage.transform.position;
            directionToTarget.y = 0;  // Ignora el eje Y para que solo gire en el plano horizontal

            // Calcula el ángulo hacia el destino (usando Mathf.Atan2)
            float angle = Mathf.Atan2(directionToTarget.x, directionToTarget.z) * Mathf.Rad2Deg;

            // Aplica la rotación suavemente en el plano 2D (eje Z)
            arrowImage.transform.rotation = Quaternion.Euler(0f, 0f, -angle);
        }
    }

    public void SetTargetPoint(int pointIndex)
    {
        // Cambia el punto de destino (0, 1, o 2)
        if (pointIndex >= 0 && pointIndex < points.Length)
        {
            targetPoint = points[pointIndex];
        }
    }

    // Llamar a esta función cuando el personaje haya llegado a un punto
    public void PointReached()
    {
        // Elige el siguiente punto
        currentTargetIndex = (currentTargetIndex + 1) % points.Length;
        SetTargetPoint(currentTargetIndex);
    }
}

