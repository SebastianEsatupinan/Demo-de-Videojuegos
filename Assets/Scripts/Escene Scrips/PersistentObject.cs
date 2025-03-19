using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    private static PersistentObject _instance;

    private void Awake()
    {
        // Si ya existe una instancia, destruye esta para mantener solo una
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // Si no, establece esta instancia como la única y no la destruyas al cargar nuevas escenas
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
