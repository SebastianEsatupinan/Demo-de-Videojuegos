using UnityEngine;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ContadorFinal : MonoBehaviour
{
    public TextMeshProUGUI textoTiempo;
    public float tiempoTotal = 180f; // 3 minutos en segundos

    private float tiempoRestante;
    private bool juegoFinalizado = false;

    void Start()
    {
        tiempoRestante = tiempoTotal;
        ActualizarTextoTiempo();
    }

    void Update()
    {
        if (juegoFinalizado) return;

        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0)
        {
            tiempoRestante = 0;
            ActualizarTextoTiempo();
            FinalizarJuego();
        }
        else
        {
            ActualizarTextoTiempo();
        }
    }

    void ActualizarTextoTiempo()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60f);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60f);
        textoTiempo.text = $"Tiempo: {minutos:00}:{segundos:00}";
    }

    void FinalizarJuego()
    {
        juegoFinalizado = true;
        textoTiempo.text = "¡Tiempo agotado!";
        Debug.Log("El tiempo se ha agotado. Finalizando el juego.");

#if UNITY_EDITOR
        EditorApplication.isPlaying = false; // Detiene PlayMode si estás en el editor
#else
        Application.Quit(); // Cierra el juego si es una build
#endif
    }
}
