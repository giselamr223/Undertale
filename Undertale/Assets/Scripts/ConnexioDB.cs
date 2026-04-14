using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;

public class ConnexioDB : MonoBehaviour
{
    private MongoClient client;
    private IMongoDatabase database;
    public static IMongoCollection<BsonDocument> usersCollection;

    void Start()
    {
        string connectionString = "mongodb+srv://a25unaforcas_db_user:PbMYfbacegSK8bNP@cluster0.xbths3k.mongodb.net/";

        try
        {
            client = new MongoClient(connectionString);
            database = client.GetDatabase("UndertaleDB"); // Your database name
            usersCollection = database.GetCollection<BsonDocument>("a25unaforcas_db_user"); // Example collection
        }
        catch (System.Exception e)
        {
            Debug.LogError("MongoDB Connection Error: " + e.Message);
        }
    }
}