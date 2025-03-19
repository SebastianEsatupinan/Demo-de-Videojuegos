using UnityEngine;
using TMPro;

public class ButtonController : MonoBehaviour
{
    public GameObject objeto1;
    public GameObject objeto2;
    public TextMeshProUGUI textoTMP;
    public AudioSource audioSource; // Asigna tu AudioSource desde el Inspector

    public AudioClip sonidoClic; // Asigna tu sonido desde el Inspector

    void OnMouseDown()
    {
        DesactivarObjetos();
        CambiarTexto();
        ReproducirSonido();
    }

    void DesactivarObjetos()
    {
        objeto1.SetActive(false);
        objeto2.SetActive(false);
    }

    void CambiarTexto()
    {
        if (textoTMP != null)
        {
            textoTMP.text = "¡Bien hecho! ahora encuentra la salida";
        }
        else
        {
            Debug.LogWarning("No se ha asignado un objeto TextMeshPro para cambiar el texto.");
        }
    }

    void ReproducirSonido()
    {
        if (audioSource != null && sonidoClic != null)
        {
            audioSource.PlayOneShot(sonidoClic);
        }
        else
        {
            Debug.LogWarning("AudioSource o sonido no asignados. Asegúrate de asignarlos desde el Inspector.");
        }
    }
}