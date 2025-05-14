using UnityEngine;
using System.IO;

public class PuntajeSaveSystem : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        GuardarPuntaje();
    }

    void GuardarPuntaje()
    {
        PuntajeData data = new PuntajeData
        {
            puntajeFinal = PuntajeManager.Instance.puntajeActual,
            fecha = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.persistentDataPath + "/puntaje_temp.json", json);
        Debug.Log("Puntaje guardado en: " + Application.persistentDataPath);
    }
}

[System.Serializable]
public class PuntajeData
{
    public int puntajeFinal;
    public string fecha;
}
