// PlayerController.cs
using UnityEngine;
using System.Collections;

namespace KikiNgao.SimpleBikeControl
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Setting")]
        public bool disable;
        [SerializeField] private string AnimSpeedParaName = "Speed";
        [SerializeField] private float runSpeed = 3f;
        [SerializeField] private float turnSpeed = 10f;
        [SerializeField] private float rotationDamping = 40f;
        [SerializeField] private float gravity = -9.8f;
        [SerializeField] private bool stopMoverment = false;

        private float velocidadOriginal;
        private Coroutine boostCoroutine;

        public bool moving { get; private set; }

        private Vector3 m_MoveVector;
        private Vector3 m_Velocity;
        private Vector3 gravityMagnitude;
        private Quaternion desiredRotation = Quaternion.identity;

        private CharacterController characterCtrl;
        [HideInInspector] public Animator m_Animator;
        private Transform camTrans;
        private Vector3 camForward;
        private InputManager inputManager;

        private void Start()
        {
            inputManager = GameManager.Instance.GetInputManager;
            characterCtrl = GetComponent<CharacterController>();
            m_Animator = GetComponent<Animator>();
            camTrans = Camera.main.transform;
            gravityMagnitude = new Vector3(0f, gravity, 0f);

            velocidadOriginal = runSpeed;
        }

        private void FixedUpdate()
        {
            if (disable) return;

            float inputSpeed = Mathf.Clamp01(
                Mathf.Abs(inputManager.horizontal) +
                Mathf.Abs(inputManager.vertical)
            );
            bool hasHInput = !Mathf.Approximately(inputManager.horizontal, 0f);
            bool hasVInput = !Mathf.Approximately(inputManager.vertical, 0f);
            moving = !stopMoverment && (hasHInput || hasVInput);

            if (camTrans != null)
            {
                camForward = Vector3.Scale(camTrans.forward, new Vector3(1, 0, 1)).normalized;
                m_MoveVector = inputManager.vertical * camForward + inputManager.horizontal * camTrans.right;
                m_MoveVector.Normalize();
            }

            // Aplica la velocidad actual (runSpeed)
            m_Velocity = inputSpeed * m_MoveVector * runSpeed * Time.deltaTime;
            if (!characterCtrl.isGrounded)
                m_Velocity += gravityMagnitude;

            m_Animator.SetFloat(AnimSpeedParaName, inputSpeed);

            Vector3 targetForward = Vector3.RotateTowards(
                transform.forward,
                m_MoveVector,
                turnSpeed * Time.deltaTime,
                0f
            );
            desiredRotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(targetForward),
                turnSpeed
            );
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                desiredRotation,
                Time.deltaTime * rotationDamping
            );

            characterCtrl.Move(m_Velocity);
        }

        public void DisablePlayerCtrl()
        {
            disable = true;
            characterCtrl.enabled = false;
        }

        public void EnablePlayerCtrl()
        {
            disable = false;
            characterCtrl.enabled = true;
        }

        /// <summary>
        /// Aplica un boost de velocidad extra durante 'duracion' segundos.
        /// </summary>
        public void AplicarPowerUpVelocidad(float bonus, float duracion)
        {
            if (boostCoroutine != null)
                StopCoroutine(boostCoroutine);

            boostCoroutine = StartCoroutine(BoostVelocidad(bonus, duracion));
        }

        private IEnumerator BoostVelocidad(float bonus, float duracion)
        {
            runSpeed += bonus;
            Debug.Log($"[PlayerController] Power-Up ON → Velocidad = {runSpeed:F2}");

            yield return new WaitForSeconds(duracion);

            runSpeed = velocidadOriginal;
            Debug.Log($"[PlayerController] Power-Up OFF → Velocidad restaurada = {runSpeed:F2}");
        }

        /// <summary>
        /// Método para sumar puntos al jugador.
        /// Sustituye el cuerpo de este método con tu propio sistema de puntuación.
        /// </summary>
        public void AddScore(int puntos)
        {
            // Ejemplo simple:
            Debug.Log($"[PlayerController] Puntos ganados: {puntos}");
            // Si tienes un ScoreManager, podrías hacer:
            // ScoreManager.Instance.Add(puntos);
        }
    }
}
