using UnityEngine;

public class GateMover : MonoBehaviour
{
    public float moveDistance = 5f; // Distancia que deben moverse los objetos
    public float moveSpeed = 2f;    // Velocidad de movimiento

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition + new Vector3(moveDistance, 0f, 0f);
    }

    void Update()
    {
        if (isMoving)
        {
            MoveGate();
        }
    }

    void MoveGate()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if (transform.position == targetPosition)
        {
            isMoving = false;
        }
    }

    public void OpenGate()
    {
        isMoving = true;
    }
}
