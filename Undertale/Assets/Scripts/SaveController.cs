using UnityEngine;

public class SaveController : MonoBehaviour
{
    public PlayerController playerStats;
    public SaveManager saveManager;

    private bool isPlayerInTrigger = false;

    void Awake()
    {
        if (playerStats == null)
        {
            playerStats = FindObjectOfType<PlayerController>();
        }

        if (saveManager == null)
        {
            saveManager = FindObjectOfType<SaveManager>();
        }
    }

    void Update()
    {
        if (isPlayerInTrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Debug.Log("GUARDANDO...");

                if (playerStats == null)
                {
                    Debug.LogError("playerStats is null");
                    return;
                }

                if (saveManager == null)
                {
                    Debug.LogError("saveManager is null");
                    return;
                }

                string json = JsonUtility.ToJson(playerStats.playerData, true);
                saveManager.SaveGame(json);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            Debug.Log("PLAYER INSIDE SAVE POINT");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            Debug.Log("PLAYER OUTSIDE SAVE POINT");
        }
    }
}