using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//simple health bar tutorial used: https://www.youtube.com/watch?v=0tDPxNB2JNs
public class HealthManager : MonoBehaviour
{
    
    //usable on Unity for the Image 
    [SerializeField] public Image healthBar;
    public float maxHP;
    
    public float currentHealth = 100f; //health at 100% at the start

    void Start(){
        maxHP = currentHealth; //setting official max health
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(currentHealth / maxHP, 0, 1); //to ensure the health doesn't overflow
        //if the player's health is zero (or less than zero for any overkill) The scene reloads using SceneManager and the build setting index for that scene
        if (currentHealth <=0 ){
            SceneManager.LoadSceneAsync(1);
        }

        //As of now, the only way to actually take damage is to press the ENTER button, I have it here to show that it is up, just not fully enabled with collisions with other objects.
       
        
    }

    
    //The Damage function to reduce the current health with how much percent of their health they have left.

    public void Damage(float damage){
        if (currentHealth > 0){
            currentHealth -= damage;
            //healthBar.fillAmount = currentHealth / 100f;
        }
    }


}
