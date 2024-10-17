// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using System.IO;

// public class MainMenu : MonoBehaviour
// {   
//     //New Part
//     private void Start()
//     {
//         // Ensure SaveLoadManager is available
//         if (SaveLoadManager.Instance == null)
//         {
//             Debug.LogError("SaveLoadManager not found in the scene!");
//         }
//     }
//     //Enabling the Play button in the Main Menu to go straight into the gameplay
//     public void PlayGame(){
//         SceneManager.LoadSceneAsync(1);
//     }

//     public void Menu(){
//         SceneManager.LoadSceneAsync(0);
//     }

//     //New Part
//     public void LoadGame()
//     {
//         if (SaveLoadManager.Instance != null)
//         {
//             string filePath = Path.Combine(Application.persistentDataPath, "gameData.dat");
//             if (File.Exists(filePath))
//             {
//                 SaveLoadManager.Instance.Load();
//             }
//             else
//             {
//                 Debug.LogWarning("No save file found. Starting a new game.");
//                 PlayGame();
//             }
//         }
//         else
//         {
//             Debug.LogError("SaveLoadManager not found!");
//         }
//     }

//     //enabling the quit button to allow the player to exit the game while the game is up
//     public void Quit(){
//         Application.Quit(); //command to exit the game
//     }

//     public void Settings(){
//         //opens the settings
//         Debug.Log("Settings opened");
//     }


// }
using UnityEngine;
using UnityEngine.SceneManagement;
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
       SceneManager.LoadScene(1);
   }


   public void LoadGame()
   {
       if (SaveLoadManager.Instance != null)
       {
               SaveLoadManager.Instance.Load();
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

       public void Menu(){
        SceneManager.LoadSceneAsync(0);
}


   public void Settings()
   {
       Debug.Log("Settings opened");
}
}
