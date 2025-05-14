using UnityEngine;
using TMPro;

public class PuntajeManager : MonoBehaviour
{
    public static PuntajeManager Instance;

    public TextMeshProUGUI textoPuntaje;
    public int puntajeActual = 0;

    private void Awake()
    {
        // Singleton para que sea accesible globalmente
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        ActualizarUI();
    }

    public void SumarPuntos(int cantidad)
    {
        puntajeActual += cantidad;
        ActualizarUI();
    }

    public void RestarPuntos(int cantidad)
    {
        puntajeActual = Mathf.Max(0, puntajeActual - cantidad);
        ActualizarUI();
    }

    private void ActualizarUI()
    {
        if (textoPuntaje != null)
            textoPuntaje.text = "Puntos: " + puntajeActual;
    }
}
