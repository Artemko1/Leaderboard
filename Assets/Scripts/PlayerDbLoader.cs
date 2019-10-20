using System;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerDbLoader : MonoBehaviour
{
    [SerializeField] private int MaxScore = 100000;
    [SerializeField] private int PlayersToCreate = 10000;
    [SerializeField] private string RelativePath = "Editor Default Resources/playerData.json";
    
    private PlayerDatabase playerDb;
    
    public PlayerDatabase LoadPlayerDb()
    {
        var filePath = Path.Combine(Application.dataPath, RelativePath);

        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            playerDb = JsonUtility.FromJson<PlayerDatabase>(json);
            print("Database loaded");
            return playerDb;
        }
        else
        {
            Debug.LogError("No json file at path " + filePath);
            return playerDb;
        }
    }
    
    
    [ContextMenu("Create new Database")]
    private void CreateNewDatabase()
    {
        GenerateNewPlayerDb();
        
        var filePath = Path.Combine(Application.dataPath, RelativePath);
        File.WriteAllText(filePath, JsonUtility.ToJson(playerDb));
        print("Saved to " + filePath);
    }

    private void GenerateNewPlayerDb()
    {
        var players = new Player[PlayersToCreate];
        
        var generator = new NameGenerator();

        for (int i = 0; i < PlayersToCreate; i++)
        {
            generator.GenerateName(out var firstName, out var surName);
            var score = Random.Range(1, MaxScore);
            players[i] = new Player(i, firstName, surName, score);
        }
        
        
        playerDb = new PlayerDatabase(){Players = players};
    }

}
