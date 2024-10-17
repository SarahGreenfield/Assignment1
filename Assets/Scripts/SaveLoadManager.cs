// using UnityEngine;
// using UnityEngine.SceneManagement;
// using System.Collections;


// public class SaveLoadManager : MonoBehaviour
// {
//    public static SaveLoadManager Instance { get; private set; }


//    private const string SceneIndexKey = "LastPlayedSceneIndex";
//    private const string PlayerPositionXKey = "PlayerPositionX";
//    private const string PlayerPositionYKey = "PlayerPositionY";
//    private const string PlayerPositionZKey = "PlayerPositionZ";
//    private const string PlayerHealthKey = "PlayerHealth";


//    private void Awake()
//    {
//        if (Instance == null)
//        {
//            Instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else
//        {
//            Destroy(gameObject);
//        }
//    }


//    public void Save()
//    {
//        // Save current scene index
//        PlayerPrefs.SetInt(SceneIndexKey, SceneManager.GetActiveScene().buildIndex);


//        // Save player position
//        PlayerMovement player = FindObjectOfType<PlayerMovement>();
//        if (player != null)
//        {
//            PlayerPrefs.SetFloat(PlayerPositionXKey, player.transform.position.x);
//            PlayerPrefs.SetFloat(PlayerPositionYKey, player.transform.position.y);
//            PlayerPrefs.SetFloat(PlayerPositionZKey, player.transform.position.z);
//        }


//        // Save player health
//        HealthManager healthManager = FindObjectOfType<HealthManager>();
//        if (healthManager != null)
//        {
//            PlayerPrefs.SetFloat(PlayerHealthKey, healthManager.GetHealth());
//        }


//        // Save all modifications
//        PlayerPrefs.Save();


//        Debug.Log("Game saved successfully.");
//    }


//    public void Load()
//    {
//        if (PlayerPrefs.HasKey(SceneIndexKey))
//        {
//            int sceneToLoad = PlayerPrefs.GetInt(SceneIndexKey);
//            SceneManager.LoadScene(sceneToLoad);


//            // Set player data after scene is loaded
//            StartCoroutine(SetPlayerDataAfterSceneLoad());
//        }
//        else
//        {
//            Debug.LogWarning("No saved game found!");
//        }
//    }


//    private IEnumerator SetPlayerDataAfterSceneLoad()
//    {
//        // Wait for the end of frame to ensure all objects are initialized
//        yield return new WaitForEndOfFrame();


//        // Set player position
//        PlayerMovement player = FindObjectOfType<PlayerMovement>();
//        if (player != null && PlayerPrefs.HasKey(PlayerPositionXKey))
//        {
//            float x = PlayerPrefs.GetFloat(PlayerPositionXKey);
//            float y = PlayerPrefs.GetFloat(PlayerPositionYKey);
//            float z = PlayerPrefs.GetFloat(PlayerPositionZKey);
//            player.transform.position = new Vector3(x, y, z);
//        }
//        else
//        {
//            Debug.LogWarning("Player not found in the scene or position data not saved!");
//        }


//        // Set player health
//        HealthManager healthManager = FindObjectOfType<HealthManager>();
//        if (healthManager != null && PlayerPrefs.HasKey(PlayerHealthKey))
//        {
//            float health = PlayerPrefs.GetFloat(PlayerHealthKey);
//            healthManager.SetHealth(health);
//        }
//        else
//        {
//            Debug.LogWarning("HealthManager not found in the scene or health data not saved!");
//        }


//        Debug.Log("Game loaded successfully.");
//    }


//    // Optional: Method to clear all saved data
//    public void ClearSavedData()
//    {
// }
// }

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class SaveLoadManager : MonoBehaviour
{
  public static SaveLoadManager Instance { get; private set; }


  private const string SceneIndexKey = "LastPlayedSceneIndex";
  private const string PlayerPositionXKey = "PlayerPositionX";
  private const string PlayerPositionYKey = "PlayerPositionY";
  private const string PlayerPositionZKey = "PlayerPositionZ";
  private const string PlayerHealthKey = "PlayerHealth";


  private void Awake()
  {
      if (Instance == null)
      {
          Instance = this;
          DontDestroyOnLoad(gameObject);
      }
      else
      {
          Destroy(gameObject);
      }
  }


  public void Save()
  {
      // Save current scene index
      PlayerPrefs.SetInt(SceneIndexKey, SceneManager.GetActiveScene().buildIndex);


      // Save player position
      PlayerMovement player = FindObjectOfType<PlayerMovement>();
      if (player != null)
      {
          PlayerPrefs.SetFloat(PlayerPositionXKey, player.transform.position.x);
          PlayerPrefs.SetFloat(PlayerPositionYKey, player.transform.position.y);
          PlayerPrefs.SetFloat(PlayerPositionZKey, player.transform.position.z);
      }


      // Save player health
      HealthManager healthManager = FindObjectOfType<HealthManager>();
      if (healthManager != null)
      {
          PlayerPrefs.SetFloat(PlayerHealthKey, healthManager.GetHealth());
      }


      // Save all modifications
      PlayerPrefs.Save();


      Debug.Log("Game saved successfully.");
  }


   public void Load()
  {
      if (PlayerPrefs.HasKey(SceneIndexKey))
      {
          int sceneToLoad = PlayerPrefs.GetInt(SceneIndexKey);
          SceneManager.LoadScene(sceneToLoad);


          // Set player data after scene is loaded
          StartCoroutine(SetPlayerDataAfterSceneLoad());
      }
      else
      {
          Debug.LogWarning("No saved game found!");
      }
  }


  private IEnumerator SetPlayerDataAfterSceneLoad()
  {
      // Wait for the end of frame to ensure all objects are initialized
      yield return new WaitForEndOfFrame();


      // Set player position
      PlayerMovement player = FindObjectOfType<PlayerMovement>();
      if (player != null && PlayerPrefs.HasKey(PlayerPositionXKey))
      {
          float x = PlayerPrefs.GetFloat(PlayerPositionXKey);
          float y = PlayerPrefs.GetFloat(PlayerPositionYKey);
          float z = PlayerPrefs.GetFloat(PlayerPositionZKey);
          player.transform.position = new Vector3(x, y, z);
      }
      else
      {
          Debug.LogWarning("Player not found in the scene or position data not saved!");
      }


      // Set player health
      HealthManager healthManager = FindObjectOfType<HealthManager>();
      if (healthManager != null && PlayerPrefs.HasKey(PlayerHealthKey))
      {
          float health = PlayerPrefs.GetFloat(PlayerHealthKey);
          healthManager.SetHealth(health);
      }
      else
      {
          Debug.LogWarning("HealthManager not found in the scene or health data not saved!");
      }


      Debug.Log("Game loaded successfully.");
  }


  // Optional: Method to clear all saved data
  public void ClearSavedData()
  {
       PlayerPrefs.DeleteAll();
       Debug.Log("All saved game data cleared.");
}
}







