using UnityEngine;
using MongoDB.Bson;
using System.Threading.Tasks;

public class MongoManager : MonoBehaviour
{

    [System.Serializable]
    public class PlayerData // Clase que representa los datos del jugador (Es de prueba, nada definitivo)
    {   // Stats
        public string playerName;
        public int level;
        public int hp;
    }
    
    async void Start() //Evento start
    {
        await Task.Delay(1000); // Un delay, para assegurar la connexion a la base de datos.
        await SaveTestData();
    }

    public async Task SaveTestData() // Método para guardar datos de prueba en MongoDB
    {
        if (ConnexioDB.usersCollection == null) // Si no hay conexión a MongoDB, se muestra un error.
        {
            Debug.LogError("No hay conexión a MongoDB");
            return;
        }

        PlayerData player = new PlayerData() 
        {
            playerName = "Frisk",
            level = 5,
            hp = 20
        };

        var document = player.ToBsonDocument(); // Pasa los datos del jugador a BSON.

        await ConnexioDB.usersCollection.InsertOneAsync(document); // Inserta el documento en la base de MongoDB

        Debug.Log("Datos guardados en MongoDB");
    }
}