using UnityEngine;
using UnityEngine.UI;

public class ColliderTrigger : MonoBehaviour
{
    public Collider targetCollider;  // Colisionador que queremos detectar
    public GameObject panel;         // Panel que queremos activar
    public Button interactButton;    // Botón de interacción dentro del panel
    private bool isOnBike = false;   // Para saber si el jugador está en la moto

    private void Start()
    {
        // Inicialmente, el panel está apagado
        if (panel != null)
        {
            panel.SetActive(false);
        }

        // Aseguramos que el botón de interacción esté escuchando el evento de clic
        if (interactButton != null)
        {
            interactButton.onClick.AddListener(OnInteractButtonClicked);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra al colisionador es el objetivo (la moto)
        if (other == targetCollider)
        {
            // Solo activamos el panel si el jugador no está en la moto
            if (!isOnBike && panel != null)
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
            // Solo desactivamos el panel si el jugador no está en la moto
            if (!isOnBike && panel != null)
            {
                panel.SetActive(false);
            }
        }
    }

    // Función que se llama cuando el botón de interacción es presionado
    private void OnInteractButtonClicked()
    {
        // Si el panel está activado y el jugador está en la moto, lo apagamos
        if (panel.activeSelf)
        {
            panel.SetActive(false);
            isOnBike = false;  // El jugador se baja de la moto
        }
        else
        {
            // Si el panel no está activado, significa que el jugador se ha vuelto a acercar o ha interactuado en la moto
            isOnBike = true;  // El jugador sube a la moto
        }
    }
}

