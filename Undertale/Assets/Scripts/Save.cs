using System.Diagnostics;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    // Esta funcion se encarga de guardar el juego.
    public void SaveGame(string json)
    {
        // Ruta del archivo JAR que se encargará de guardar los datos en MongoDB.
        // Este archivo JAR es un programa Java que se encargará de recibir los datos en formato JSON y guardarlos en MongoDB.
        string jarPath = Application.dataPath + "/../External/SaveSystem/SaveSystem.jar";

        json = json.Replace("\"", "\\\""); // Esto ayuda al programa a inerpretar bien el JSON.

        Process p = new Process();
        p.StartInfo.FileName = "java";
        p.StartInfo.Arguments = "-jar \"" + jarPath + "\" \"" + json + "\"";
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.CreateNoWindow = true;

        p.Start();

        string output = p.StandardOutput.ReadToEnd();
        p.WaitForExit();

        UnityEngine.Debug.Log("Java dice: " + output);
    }
}