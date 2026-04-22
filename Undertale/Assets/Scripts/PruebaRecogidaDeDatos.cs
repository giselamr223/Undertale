using UnityEngine;
using MongoDB.Bson;
using System.Threading.Tasks;
using System;

public class MongoManager : MonoBehaviour
{
    void OnApplicationQuit()
    {
        SaveMovementCount();
    }

    public void SaveMovementCount()
    {
        BsonDocument document;

        if (ConnexioDB.usersCollection == null)
        {
            Debug.LogError("No hay conexión a MongoDB");
            return;
        }

        document = new BsonDocument();

        document.Add("movementCount", CountMovement.movementCount);
        document.Add("date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        ConnexioDB.usersCollection.InsertOne(document);

        Debug.Log("Datos guardados en MongoDB");
    }
}