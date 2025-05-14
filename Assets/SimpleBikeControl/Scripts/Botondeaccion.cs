using UnityEngine;
using UnityEngine.UI;

public class ColliderTrigger : MonoBehaviour
{
    public Collider targetCollider;
    public GameObject panel;

    private bool isPlayerInside = false;
    private bool yaInteractuo = false;

    private void Start()
    {
        if (panel != null)
            panel.SetActive(false);
    }

    private void Update()
    {
        // Si el jugador está dentro, no ha interactuado aún, y presiona F
        if (isPlayerInside && !yaInteractuo && Input.GetKeyDown(KeyCode.F))
        {
            panel.SetActive(false);     // Ocultar panel
            yaInteractuo = true;        // Evitar que vuelva a mostrarse
            Debug.Log("Interactuó con F");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == targetCollider && !yaInteractuo)
        {
            isPlayerInside = true;

            if (panel != null)
                panel.SetActive(true);  // Mostrar panel al acercarse
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == targetCollider)
        {
            isPlayerInside = false;
            yaInteractuo = false;       // Permitir que el panel vuelva a aparecer en el futuro

            if (panel != null)
                panel.SetActive(false); // Ocultar panel al salir del área
        }
    }
}
