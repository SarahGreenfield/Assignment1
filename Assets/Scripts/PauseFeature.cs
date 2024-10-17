using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this is the script for the pausing feature
public class PauseFeature : MonoBehaviour
{
    //object/references
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    
    private PlayerMovement playerMovement;
    private HealthManager healthManager;

    void Start(){
        //accessing objects from the PlayerMovement and HealthManager classes
        playerMovement = FindObjectOfType<PlayerMovement>();
        healthManager = FindObjectOfType<HealthManager>();

        // initially set the pauseMenu boolean to false
        pauseMenuUI.SetActive(false);
    }

    void Update(){
        //Check for Excape key press
        if(Input.GetKeyDown(KeyCode.Escape) ){
            //resumes game if game is already paused
            if(GameIsPaused){
                Resume();
            }
            //pauses the game
            else{
                Pause();
            }
        }
    }

    //The pause function, it freezes the game time and disables the player movement and health manager
    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        playerMovement.enabled = false;
        healthManager.enabled = false;
    }

    //the resume function, enables the player movement and health manager along with unfreezing time.
    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        playerMovement.enabled = true;
        healthManager.enabled = true;
    }

    public void Restart(){
        Resume();

        SceneManager.LoadScene(0);
    }

    public void OpenSettings(){
        Debug.Log("Settings opened");
    }

    //New Part
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
