using UnityEngine;

public class PowerUpSpeed : PowerUp
{
    public float speedMultiplier = 2f;

    protected override void ApplyEffect(GameObject player)
    {
        PlayerController controller = player.GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.MovementSpeed *= speedMultiplier;
            Debug.Log("Velocidad aumentada a: " + controller.MovementSpeed);
        }
    }

    protected override void RemoveEffect(GameObject player)
    {
        PlayerController controller = player.GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.MovementSpeed /= speedMultiplier;
            Debug.Log("Velocidad normalizada a: " + controller.MovementSpeed);
        }
    }
}
