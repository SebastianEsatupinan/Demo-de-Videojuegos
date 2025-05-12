using UnityEngine;

public class PuntoEntrega : MonoBehaviour
{
    private Entregas sistemaEntregas;

    void Start()
    {
        sistemaEntregas = FindObjectOfType<Entregas>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que tu jugador tenga el tag "Player"
        {
            sistemaEntregas.PuntoAlcanzado(gameObject);

            PedidoManager pedidoManager = FindObjectOfType<PedidoManager>();
            if (pedidoManager != null)

            {
                pedidoManager.CompletarPedido();
            }

        }
    }
}
