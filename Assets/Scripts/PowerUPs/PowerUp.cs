// PowerUp.cs
using UnityEngine;
using System.Collections;

namespace KikiNgao.SimpleBikeControl
{
    [RequireComponent(typeof(Collider))]
    public class PowerUp : MonoBehaviour
    {
        public enum TipoPowerUp { Velocidad10s, Velocidad15s }

        [Header("Tipo de Power-Up")]
        public TipoPowerUp tipo = TipoPowerUp.Velocidad10s;

        [Header("Rango de Boost de Velocidad")]
        [Tooltip("Valor mínimo de velocidad extra")]
        public float minVelExtra = 1f;
        [Tooltip("Valor máximo de velocidad extra")]
        public float maxVelExtra = 5f;

        [Header("Rango de Puntuación")]
        [Tooltip("Puntos mínimos que otorga")]
        public int minPuntaje = 10;
        [Tooltip("Puntos máximos que otorga")]
        public int maxPuntaje = 50;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            var player = other.GetComponent<PlayerController>();
            if (player == null)
            {
                Debug.LogError("PowerUp: no se encontró PlayerController en el Player.");
                return;
            }

            // 10s ó 15s según tipo
            float duracion = (tipo == TipoPowerUp.Velocidad15s) ? 15f : 10f;
            // elige aleatorio en los rangos
            float velocidadRandom = Random.Range(minVelExtra, maxVelExtra);
            int puntajeRandom = Random.Range(minPuntaje, maxPuntaje + 1);

            Debug.Log($"[PowerUp] +{velocidadRandom:F2} velocidad por {duracion:F0}s y +{puntajeRandom} puntos.");

            // Aplica el boost de velocidad
            player.AplicarPowerUpVelocidad(velocidadRandom, duracion);
            // Suma los puntos al gestor global
            PuntajeManager.Instance.SumarPuntos(puntajeRandom);

            Destroy(gameObject);
        }
    }
}