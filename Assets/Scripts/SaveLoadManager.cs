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



// One we have right now

// using UnityEngine;
// using UnityEngine.SceneManagement;
// using System.Collections;


// public class SaveLoadManager : MonoBehaviour
// {
//   public static SaveLoadManager Instance { get; private set; }


//   private const string SceneIndexKey = "LastPlayedSceneIndex";
//   private const string PlayerPositionXKey = "PlayerPositionX";
//   private const string PlayerPositionYKey = "PlayerPositionY";
//   private const string PlayerPositionZKey = "PlayerPositionZ";
//   private const string PlayerHealthKey = "PlayerHealth";


//   private void Awake()
//   {
//       if (Instance == null)
//       {
//           Instance = this;
//           DontDestroyOnLoad(gameObject);
//       }
//       else
//       {
//           Destroy(gameObject);
//       }
//   }


//   public void Save()
//   {
//       // Save current scene index
//       PlayerPrefs.SetInt(SceneIndexKey, SceneManager.GetActiveScene().buildIndex);


//       // Save player position
//       PlayerMovement player = FindObjectOfType<PlayerMovement>();
//       if (player != null)
//       {
//           PlayerPrefs.SetFloat(PlayerPositionXKey, player.transform.position.x);
//           PlayerPrefs.SetFloat(PlayerPositionYKey, player.transform.position.y);
//           PlayerPrefs.SetFloat(PlayerPositionZKey, player.transform.position.z);
//       }


//       // Save player health
//       HealthManager healthManager = FindObjectOfType<HealthManager>();
//       if (healthManager != null)
//       {
//           PlayerPrefs.SetFloat(PlayerHealthKey, healthManager.GetHealth());
//       }


//       // Save all modifications
//       PlayerPrefs.Save();


//       Debug.Log("Game saved successfully.");
//   }


//    public void Load()
//   {
//       if (PlayerPrefs.HasKey(SceneIndexKey))
//       {
//           int sceneToLoad = PlayerPrefs.GetInt(SceneIndexKey);
//           SceneManager.LoadScene(sceneToLoad);


//           // Set player data after scene is loaded
//           StartCoroutine(SetPlayerDataAfterSceneLoad());
//       }
//       else
//       {
//           Debug.LogWarning("No saved game found!");
//       }
//   }


//   private IEnumerator SetPlayerDataAfterSceneLoad()
//   {
//       // Wait for the end of frame to ensure all objects are initialized
//       yield return new WaitForEndOfFrame();


//       // Set player position
//       PlayerMovement player = FindObjectOfType<PlayerMovement>();
//       if (player != null && PlayerPrefs.HasKey(PlayerPositionXKey))
//       {
//           float x = PlayerPrefs.GetFloat(PlayerPositionXKey);
//           float y = PlayerPrefs.GetFloat(PlayerPositionYKey);
//           float z = PlayerPrefs.GetFloat(PlayerPositionZKey);
//           player.transform.position = new Vector3(x, y, z);
//       }
//       else
//       {
//           Debug.LogWarning("Player not found in the scene or position data not saved!");
//       }


//       // Set player health
//       HealthManager healthManager = FindObjectOfType<HealthManager>();
//       if (healthManager != null && PlayerPrefs.HasKey(PlayerHealthKey))
//       {
//           float health = PlayerPrefs.GetFloat(PlayerHealthKey);
//           healthManager.SetHealth(health);
//       }
//       else
//       {
//           Debug.LogWarning("HealthManager not found in the scene or health data not saved!");
//       }


//       Debug.Log("Game loaded successfully.");
//   }


//   // Optional: Method to clear all saved data
//   public void ClearSavedData()
//   {
//        PlayerPrefs.DeleteAll();
//        Debug.Log("All saved game data cleared.");
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

[ContextMenu("ActionName")]
public void PrintPrefs()
{
    //Debug All player pref values
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
           StartCoroutine(LoadSceneAndSetData(sceneToLoad));
     }
     else
     {
         Debug.LogWarning("No saved game found!");
     }
 }


   private IEnumerator LoadSceneAndSetData(int sceneIndex)
 {
       AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);


       while (!asyncLoad.isDone)
     {
           yield return null;
     }


       // Scene is fully loaded, now set the data
       SetPlayerData();
     }


   private void SetPlayerData()
     {
       // Set player position
       PlayerMovement player = FindObjectOfType<PlayerMovement>();
       if (player != null && PlayerPrefs.HasKey(PlayerPositionXKey))
       {
           float x = PlayerPrefs.GetFloat(PlayerPositionXKey);
           float y = PlayerPrefs.GetFloat(PlayerPositionYKey);
           float z = PlayerPrefs.GetFloat(PlayerPositionZKey);
           player.transform.position = new Vector3(x, y, z);
     }


       // Set player health
       HealthManager healthManager = FindObjectOfType<HealthManager>();
       if (healthManager != null && PlayerPrefs.HasKey(PlayerHealthKey))
 {
           float health = PlayerPrefs.GetFloat(PlayerHealthKey);
           healthManager.SetHealth(health);
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





