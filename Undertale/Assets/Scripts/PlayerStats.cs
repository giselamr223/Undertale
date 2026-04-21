using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [System.Serializable]
    public class PlayerData
    {
        public string playerName;
        public int level;
        public int hp;

        public override string ToString()
        {
            return "Name: " + playerName + "Level:" + level + "HP:" + hp;
        }

    }

    public PlayerData data = new PlayerData();
    
    void Start()
    {
        data.playerName = "Freak";
        data.level = 1;
        data.hp = 100;
    }

}
