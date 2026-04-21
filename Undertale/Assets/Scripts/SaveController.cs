using UnityEngine;

public class SaveController : MonoBehaviour
{
    public PlayerStats playerStats;
    public SaveManager saveManager;

    void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        saveManager = FindObjectOfType<SaveManager>();
    }

    void Update()
    {   // Si presiona la tecla G para guardar el juego
        // (hay que modificar la tecla si es necesario o el tipo de sistema de captura o guardado).
        if (Input.GetKeyDown(KeyCode.G))
        {
            UnityEngine.Debug.Log("GUARDANDO...");

            string json = JsonUtility.ToJson(playerStats.data, true);
            saveManager.SaveGame(json);
        }
    }
}