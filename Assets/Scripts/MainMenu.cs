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
