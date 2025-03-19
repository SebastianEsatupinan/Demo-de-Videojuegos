using UnityEngine;

public class PowerUpJump : PowerUp
{
    public float jumpMultiplier = 1.5f;

    protected override void ApplyEffect(GameObject player)
    {
        PlayerController controller = player.GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.JumpForce *= jumpMultiplier;
            Debug.Log("Salto aumentado a: " + controller.JumpForce);
        }
    }

    protected override void RemoveEffect(GameObject player)
    {
        PlayerController controller = player.GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.JumpForce /= jumpMultiplier;
            Debug.Log("Salto normalizado a: " + controller.JumpForce);
        }
    }
}
