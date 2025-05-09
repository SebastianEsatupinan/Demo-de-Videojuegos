using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    public GameObject panelPausa;             // El panel UI del menú de pausa
    public AudioSource musicaFondo;           // Audio de música que se pausa
    public AudioClip sonidoClick;             // Sonido del botón
    private AudioSource audioSource;          // Fuente para reproducir efectos
    private bool juegoPausado = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (panelPausa != null)
            panelPausa.SetActive(false); // Ocultar al inicio
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
                ReanudarJuego();
            else
                PausarJuego();
        }
    }

    public void PausarJuego()
    {
        ReproducirSonido();
        panelPausa.SetActive(true);
        Time.timeScale = 0f; // Pausar el juego
        juegoPausado = true;
        if (musicaFondo != null)
            musicaFondo.Pause();
    }

    public void ReanudarJuego()
    {
        ReproducirSonido();
        panelPausa.SetActive(false);
        Time.timeScale = 1f; // Reanudar el juego
        juegoPausado = false;
        if (musicaFondo != null)
            musicaFondo.Play();
    }

    void ReproducirSonido()
    {
        if (sonidoClick != null && audioSource != null)
            audioSource.PlayOneShot(sonidoClick);
    }
}
