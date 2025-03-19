using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float duration = 5f; // Duración del efecto

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyEffect(other.gameObject);
            GetComponent<Collider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(DisableAfterTime(other.gameObject));
        }
    }

    protected virtual void ApplyEffect(GameObject player) { }
    protected virtual void RemoveEffect(GameObject player) { }

    IEnumerator DisableAfterTime(GameObject player)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            Debug.Log("Power-up activo. Tiempo restante: " + (duration - elapsedTime) + " segundos.");
            yield return new WaitForSeconds(1f);
            elapsedTime += 1f;
        }

        RemoveEffect(player);
        Debug.Log("Power-up ha terminado.");
    }
}