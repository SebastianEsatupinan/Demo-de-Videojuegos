using UnityEngine;
//KikiNgao.SimpleBikeControl.PlayerController player = other.GetComponent<KikiNgao.SimpleBikeControl.PlayerController>();




public class PowerUp : MonoBehaviour
{

    public enum TipoPowerUp { Velocidad10s, Velocidad15s }
    public TipoPowerUp tipo;

    public float velocidadExtra = 3f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colisión con: " + other.name); // Verificación básica

        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Colisión con el jugador!");

            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                float duracion = tipo == TipoPowerUp.Velocidad15s ? 15f : 10f;
                //player.AplicarPowerUpVelocidad(velocidadExtra, duracion);
            }

            Destroy(gameObject); // Elimina la esfera
        }
    }
}//
