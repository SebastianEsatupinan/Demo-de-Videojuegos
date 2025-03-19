using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContoladorPaneles : MonoBehaviour
{
    // Referencia al GameObject del panel que se mostrará u ocultará.

    public GameObject panel;

    // Método para mostrar el panel.

    public void MostrarPanel()
    {
        // Activa el panel, haciéndolo visible.

        panel.SetActive(true);
    }
    // Método para ocultar el panel.

    public void OcultarPanel()
    {
        // Desactiva el panel, haciéndolo invisible.
        panel.SetActive(false);
    }
}

//sebastian Estupiñán Sánchez #2200361
//Juan David Carvajal #2221496
//David Alejandro Perez #2201374
//Miguel Diuza 2215595