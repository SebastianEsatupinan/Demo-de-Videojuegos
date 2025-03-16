using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeEnemi1 : MonoBehaviour
{
    public GameObject prefabAInstanciar; // Asigna tu prefab desde el editor
    public float tiempoEntreInstancias = 2f;

    private float tiempoPasado = 0f;

    void Update()
    {
        tiempoPasado += Time.deltaTime;

        if (tiempoPasado >= tiempoEntreInstancias)
        {
            InstanciarPrefab();
            tiempoPasado = 0f;
        }
    }

    void InstanciarPrefab()
    {
        // Puedes ajustar la posición y la rotación según tus necesidades
        Instantiate(prefabAInstanciar, transform.position, Quaternion.identity);
    }
}
