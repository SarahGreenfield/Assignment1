using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager Instance { get; private set; }

    private string saveFileName = "gameData.dat";
    private GameData gameData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            // Initialize the game data object
            gameData = new GameData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        // Collect current game state
        gameData.lastPlayedSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        if (player != null)
        {
            gameData.playerPosition = player.transform.position;
        }
        HealthManager healthManager = FindObjectOfType<HealthManager>();
        if (healthManager != null)
        {
            gameData.playerHealth = healthManager.GetHealth(); // Using the new GetHealth method
        }
        // Serialize and save game data to file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Path.Combine(Application.persistentDataPath, saveFileName));
        bf.Serialize(file, gameData);
        file.Close();
        Debug.Log("Game saved successfully.");
    }

    public void Load()
    {
        string filePath = Path.Combine(Application.persistentDataPath, saveFileName);
        if (File.Exists(filePath))
        {
            // Deserialize and load game data from file
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);
            gameData = (GameData)bf.Deserialize(file);
            file.Close();

            // Load the saved scene
            SceneManager.LoadScene(gameData.lastPlayedSceneIndex);
            
            // Set player data after scene is loaded
            StartCoroutine(SetPlayerDataAfterSceneLoad());
        }
        else
        {
            Debug.LogWarning("Save file not found!");
        }
    }

    private IEnumerator SetPlayerDataAfterSceneLoad()
    {
        // Wait for the end of frame to ensure all objects are initialized
        yield return new WaitForEndOfFrame();

        // Set player position
        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        if (player != null)
        {
            player.transform.position = gameData.playerPosition;
        }
        else
        {
            Debug.LogWarning("Player not found in the scene!");
        }

        // Set player health
        HealthManager healthManager = FindObjectOfType<HealthManager>();
        if (healthManager != null)
        {
            healthManager.SetHealth(gameData.playerHealth); // Using the new SetHealth method
        }
        else
        {
            Debug.LogWarning("HealthManager not found in the scene!");
        }

        Debug.Log("Game loaded successfully.");
    }
}