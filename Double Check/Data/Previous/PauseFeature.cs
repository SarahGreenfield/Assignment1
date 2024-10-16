using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;

public class PauseFeature : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    
    private PlayerMovement playerMovement;
    private HealthManager healthManager;

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        healthManager = FindObjectOfType<HealthManager>();
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
    }
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        playerMovement.enabled = false;
        healthManager.enabled = false;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        playerMovement.enabled = true;
        healthManager.enabled = true;
        }

    public void Restart()
    {
        Resume();
        SceneManager.LoadScene(0);
}

    public void OpenSettings()
    {
        Debug.Log("Settings opened");
    }

    public void SaveGame()
    {
        if (SaveLoadManager.Instance != null)
        {
            SaveLoadManager.Instance.Save();
            Debug.Log("Game saved");
        }
        else
        {
            Debug.LogError("SaveLoadManager not found!");
        }
    }
}