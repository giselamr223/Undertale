using UnityEngine;

public class SaveController : MonoBehaviour
{
    public PlayerController playerStats;
    public SaveManager saveManager;
    GameObject player;
    private bool isPlayerInTrigger = false;

    void Awake()
    {
        playerStats = FindObjectOfType<PlayerController>();
        saveManager = FindObjectOfType<SaveManager>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {   // Si presiona la tecla G para guardar el juego
        // (hay que modificar la tecla si es necesario o el tipo de sistema de captura o guardado).

        if (isPlayerInTrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                UnityEngine.Debug.Log("GUARDANDO...");

                string json = JsonUtility.ToJson(playerStats.playerData, true);
                saveManager.SaveGame(json);
            }

        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;

            //Destroy(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }



}

