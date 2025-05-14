using UnityEngine;
using TMPro;

public class PedidoManager : MonoBehaviour
{
    [Header("Configuración del pedido")]
    public float tiempoMaximo = 60f;
    private float tiempoRestante;
    private bool pedidoActivo = false;

    [Header("Referencias")]
    public TextMeshProUGUI textoPedido;
    public Entregas sistemaEntregas;

    [Header("Audio")]
    public AudioClip sonidoEntrega; 
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
        IniciarNuevoPedido();
    }

    void Update()
    {
        if (!pedidoActivo) return;

        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 10)
        {
            textoPedido.color = Color.red;
        }

        textoPedido.text = " Tiempo restante: " + Mathf.CeilToInt(tiempoRestante).ToString() + "s";

        if (tiempoRestante <= 0)
        {
            pedidoActivo = false;
            textoPedido.text = " ¡Pedido fallido!";
            textoPedido.color = Color.red;

            PuntajeManager.Instance?.RestarPuntos(5);


            Invoke(nameof(IniciarNuevoPedido), 3f);
        }
    }

    public void CompletarPedido()
    {
        if (!pedidoActivo) return;

        pedidoActivo = false;
        textoPedido.text = " ¡Pedido entregado!";
        textoPedido.color = Color.green;

        PuntajeManager.Instance?.SumarPuntos(10);

        // ▶ Reproducir sonido de entrega
        if (audioSource != null && sonidoEntrega != null)
        {
            audioSource.PlayOneShot(sonidoEntrega);
        }

        Invoke(nameof(IniciarNuevoPedido), 3f);
    }

    void IniciarNuevoPedido()
    {
        tiempoRestante = tiempoMaximo;
        pedidoActivo = true;

        textoPedido.color = Color.white;
        textoPedido.text = " ¡Nuevo pedido asignado!";

        sistemaEntregas.IniciarDesdePedido();
    }
}
