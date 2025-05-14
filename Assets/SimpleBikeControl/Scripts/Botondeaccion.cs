using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    public Collider targetCollider; // Colisionador que queremos detectar
    public GameObject panel; // Panel que queremos activar

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra al colisionador es el objetivo
        if (other == targetCollider)
        {
            // Activa el panel
            if (panel != null)
            {
                panel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica si el objeto que sale del colisionador es el objetivo
        if (other == targetCollider)
        {
            // Desactiva el panel cuando sale del colisionador
            if (panel != null)
            {
                panel.SetActive(false);
            }
        }
    }
}

