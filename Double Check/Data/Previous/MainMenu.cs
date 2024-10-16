using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        // Ensure SaveLoadManager is available
        if (SaveLoadManager.Instance == null)
        {
            Debug.LogError("SaveLoadManager not found in the scene!");
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void LoadGame()
    {
        if (SaveLoadManager.Instance != null)
        {
            string filePath = Path.Combine(Application.persistentDataPath, "gameData.dat");
            if (File.Exists(filePath))
            {
                SaveLoadManager.Instance.Load();
            }
            else
            {
                Debug.LogWarning("No save file found. Starting a new game.");
                PlayGame();
            }
        }
        else
        {
            Debug.LogError("SaveLoadManager not found!");
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Settings()
    {
        Debug.Log("Settings opened");
    }
}
