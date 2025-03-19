using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisionfuerademapa : MonoBehaviour
{
    public GameObject puntoSpawn;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Debug.Log("Saliste del mapa");
            other.transform.position = puntoSpawn.transform.position;
        }
    }
}
