using UnityEngine;
using TMPro;
using System.IO;

public class DashboardUI : MonoBehaviour
{
    public TextMeshProUGUI textoDashboard;

    void Start()
    {
        string path = Application.persistentDataPath + "/puntaje_temp.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PuntajeData data = JsonUtility.FromJson<PuntajeData>(json);
            textoDashboard.text = "Último puntaje: " + data.puntajeFinal + "\nFecha: " + data.fecha;
        }
        else
        {
            textoDashboard.text = "Sin puntajes previos.";
        }
    }
}
