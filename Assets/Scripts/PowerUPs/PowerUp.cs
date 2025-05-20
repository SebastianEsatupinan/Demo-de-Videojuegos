// PowerUp.cs
using UnityEngine;

namespace KikiNgao.SimpleBikeControl
{
    [RequireComponent(typeof(Collider))]
    public class PowerUp : MonoBehaviour
    {
        public enum TipoPowerUp { Velocidad10s, Velocidad15s }

        [Header("Tipo de Power-Up")]
        public TipoPowerUp tipoPowerUp = TipoPowerUp.Velocidad10s;

        [Header("Rango de Boost de Velocidad")]
        public float minVelExtra = 1f;
        public float maxVelExtra = 5f;

        [Header("Rango de Puntuación")]
        public int minPuntaje = 10;
        public int maxPuntaje = 50;

        // Método para manejar el trigger cuando el jugador entra
        private void OnTriggerEnter(Collider other)
        {
            // Verifica si el objeto tiene el tag "Player"
            if (!other.CompareTag("Player")) return;

            // Busca el PlayerController en el objeto con el tag "Player"
            var player = other.GetComponent<PlayerController>();
            if (player == null)
            {
                Debug.LogError("PowerUp: no se encontró PlayerController en el Player.");
                return;
            }

            // Determina la duración del power-up (10s o 15s)
            float duracion = (tipoPowerUp == TipoPowerUp.Velocidad15s) ? 15f : 10f;

            // Selecciona un valor aleatorio dentro del rango de velocidad extra
            float velocidadRandom = Random.Range(minVelExtra, maxVelExtra);
            int puntajeRandom = Random.Range(minPuntaje, maxPuntaje + 1);

            Debug.Log($"[PowerUp] +{velocidadRandom:F2} velocidad por {duracion:F0}s y +{puntajeRandom} puntos.");

            // Aplica el boost de velocidad al jugador
            player.AplicarPowerUpVelocidad(velocidadRandom, duracion);

            // Aumenta el puntaje del jugador
            player.AddScore(puntajeRandom);

            // Destruye el objeto PowerUp después de ser recogido
            Destroy(gameObject);
        }
    }
}
