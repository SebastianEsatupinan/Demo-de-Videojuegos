using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolectarItem : MonoBehaviour
{
    public int totalItemsRecogidos = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            totalItemsRecogidos++;
            Debug.Log("Item recogido. Total: " + totalItemsRecogidos);

            // Desaparece el objeto recogido
            Destroy(other.gameObject);
        }
    }
}
