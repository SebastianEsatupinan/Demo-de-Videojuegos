using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;           // El jugador
    public Vector3 offset = new Vector3(0, 2, -4); // Posición relativa
    public float sensitivity = 100f;
    public float distance = 5f;

    private float yaw = 0f;
    private float pitch = 0f;

    public float minPitch = -20f;
    public float maxPitch = 60f;

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 desiredPosition = target.position + rotation * offset;

        transform.position = desiredPosition;
        transform.LookAt(target);
    }
}
