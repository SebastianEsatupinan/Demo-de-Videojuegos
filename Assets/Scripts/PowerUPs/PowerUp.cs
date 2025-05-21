// PowerUp.cs
using UnityEngine;

namespace KikiNgao.SimpleBikeControl
{
    [RequireComponent(typeof(Collider))]
    public class PowerUp : MonoBehaviour
    {
        public enum TipoPowerUp { Velocidad10s, Velocidad15s }

        [Header("Referencia a PlayerController")]
        [Tooltip("Arrastra aquí el PlayerController del objeto Player. Opcional: se usará GetComponent si está vacío.")]
        [SerializeField]
        private PlayerController playerController;

        [Header("Tipo de Power-Up")]
        public TipoPowerUp tipoPowerUp = TipoPowerUp.Velocidad10s;

        [Header("Rango de Boost de Velocidad")]
        public float minVelExtra = 1f;
        public float maxVelExtra = 5f;

        [Header("Rango de Puntuación")]
        public int minPuntaje = 10;
        public int maxPuntaje = 50;

        private void OnTriggerEnter(Collider other)
        {
            // Solo reacciona al jugador con tag "Player"
            if (!other.CompareTag("Player")) return;

            // Usa el PlayerController arrastrado o busca en el colisionador
            PlayerController player = playerController != null
                ? playerController
                : other.GetComponent<PlayerController>();

            if (player == null)
            {
                Debug.LogError("PowerUp: no se encontró PlayerController en el Player. Arrastra el PlayerController en el inspector o añade el componente al objeto Player.");
                return;
            }

            // Determina la duración del power-up
            float duracion = (tipoPowerUp == TipoPowerUp.Velocidad15s) ? 15f : 10f;

            // Selecciona un valor aleatorio dentro del rango
            float velocidadRandom = Random.Range(minVelExtra, maxVelExtra);
            int puntajeRandom = Random.Range(minPuntaje, maxPuntaje + 1);

            Debug.Log($"[PowerUp] +{velocidadRandom:F2} velocidad por {duracion:F0}s y +{puntajeRandom} puntos.");

            // Aplica el boost y aumenta el puntaje
            player.AplicarPowerUpVelocidad(velocidadRandom, duracion);
            player.AddScore(puntajeRandom);

            // Destruye el objeto PowerUp después de recogerlo
            Destroy(gameObject);
        }
    }
}
