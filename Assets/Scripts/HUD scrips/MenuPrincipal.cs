using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Referencia al panel que deseas activar o desactivar
    public GameObject panelInfo;
    public AudioClip sonidoClick; // Arrastra tu clip aquí en el inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void ReproducirSonido()
    {
        if (sonidoClick != null && audioSource != null)
            audioSource.PlayOneShot(sonidoClick);
    }


    // Método para cambiar de escena
    public void CambiarEscena(string nombreEscena)
    {
        ReproducirSonido();
        SceneManager.LoadScene(nombreEscena);
    }

    // Método para activar un panel
    public void ActivarPanel()
    {
        ReproducirSonido();
        if (panelInfo != null)
            panelInfo.SetActive(true);
    }

    // Método para desactivar un panel
    public void DesactivarPanel()
    {
        ReproducirSonido();
        if (panelInfo != null)
            panelInfo.SetActive(false);
    }

    // Método para salir de la aplicación
    public void SalirAplicacion()
    {
        ReproducirSonido();
        Debug.Log("Saliendo del juego...");
        Application.Quit();

        // Para editor de Unity, esto simula salir
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
