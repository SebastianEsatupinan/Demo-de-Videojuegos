using UnityEngine;
using UnityEngine.UI;

public class UIFollowTarget : MonoBehaviour
{
    public Transform target;  // El objetivo hacia donde debe apuntar la flecha
    public RectTransform arrow;  // La flecha en la UI

    void Update()
    {
        // Obtener la dirección desde el objetivo
        Vector3 direction = target.position - Camera.main.transform.position;
        direction.y = 0;  // Para que solo se mueva en el plano horizontal

        // Calcular el ángulo de rotación en 2D
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        // Aplicar el ángulo a la rotación de la flecha
        arrow.rotation = Quaternion.Euler(0, 0, angle);
    }
}
