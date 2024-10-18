using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager Instance { get; private set; }
    private string savePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            savePath = Path.Combine(Application.persistentDataPath, "savefile.json");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to save data
    public void Save()
    {
        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        HealthManager healthManager = FindObjectOfType<HealthManager>();

        if (player != null && healthManager != null)
        {
            SaveData data = new SaveData
            {
                playerPositionX = player.transform.position.x,
                playerPositionY = player.transform.position.y,
                playerPositionZ = player.transform.position.z,
                currentScene = SceneManager.GetActiveScene().name,
                playerHealth = healthManager.GetHealth(),
                volume = AudioListener.volume
            };

            string json = JsonUtility.ToJson(data);
            File.WriteAllText(savePath, json);
            Debug.Log("Game Saved!");
        }
        else
        {
            Debug.LogWarning("Player or HealthManager not found. Unable to save game.");
        }
    }

    // Method to load data
    public void Load()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            // Load the saved scene
            StartCoroutine(LoadSceneAndSetData(data));
        }
        else
        {
            Debug.LogWarning("No save file found!");
        }
    }

    // Coroutine to load scene and set data
    private IEnumerator LoadSceneAndSetData(SaveData data)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(data.currentScene);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Scene is loaded, now set the data
        yield return new WaitForEndOfFrame();

        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        HealthManager healthManager = FindObjectOfType<HealthManager>();

        if (player != null)
        {
            player.transform.position = new Vector3(data.playerPositionX, data.playerPositionY, data.playerPositionZ);
        }

        if (healthManager != null)
        {
            healthManager.SetHealth(data.playerHealth);
        }

        AudioListener.volume = data.volume;

        Debug.Log("Game Loaded!");
    }

    // Optional: Method to clear saved data
    public void ClearSavedData()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
            Debug.Log("Saved data cleared.");
        }
    }
}

[System.Serializable]
public class SaveData
{
    public float playerPositionX;
    public float playerPositionY;
    public float playerPositionZ;
    public string currentScene;
    public float playerHealth;
    public float volume;
}


