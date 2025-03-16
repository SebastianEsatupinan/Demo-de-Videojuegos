using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    // Nombre de la escena que deseas cargar
    public string nombreDeEscena;

    // Llamado cuando ocurra algún evento que desee cambiar de escena
    public void CambiarEscena()
    {
        // Cargar la escena por su nombre
        SceneManager.LoadScene(nombreDeEscena);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Debug.Log("Saliste del nivel");
            CambiarEscena();
        }
    }
}
