using UnityEngine;
using MongoDB.Bson;
using System.Threading.Tasks;
using System;

public class MongoManager : MonoBehaviour
{
    public PlayerStats playerStats;

    void Awake() {
        playerStats = FindObjectOfType<PlayerStats>();

    }

    async void Start() //Evento start
    {
        await Task.Delay(1000); // Un delay, para assegurar la connexion a la base de datos (Si no lo ponia no se subia nada).
        await SaveTestData();
    }
    
    public async Task SaveTestData() // Funcion para guardar datos de prueba en MongoDB
    {
        if (ConnexioDB.usersCollection == null) // Si no hay conexión a MongoDB, mostrara un error.
        {
            Debug.LogError("No hay conexión a MongoDB");
            return;
        }

        PlayerStats.PlayerData player = new PlayerStats.PlayerData();

        player = playerStats.data; // Asigna los datos del jugador a la variable player.

        //Debug.LogError(player.ToString());

        var document = player.ToBsonDocument(); // Pasa los datos del jugador a BSON.

        await ConnexioDB.usersCollection.InsertOneAsync(document); // Inserta el documento en la base de MongoDB

        Debug.Log("Datos guardados en MongoDB"); // Muestra este mensaje por consola.
    }
    
}