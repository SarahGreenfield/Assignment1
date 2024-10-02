using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Enabling the Play button in the Main Menu to go straight into the gameplay
    public void PlayGame(){
        SceneManager.LoadSceneAsync(1);
    }

    //enabling the quit button to allow the player to exit the game while the game is up
    public void Quit(){
        Application.Quit(); //command to exit the game
    }
}
