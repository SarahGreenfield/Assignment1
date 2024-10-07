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
    
    public float currentHealth = 100f;  //health at 100% at the start

    // Update is called once per frame
    void Update()
    {
        //if the player's health is zero (or less than zero for any overkill) The scene reloads using SceneManager and the build setting index for that scene
        if (currentHealth <=0 ){
            SceneManager.LoadSceneAsync(1);
        }

        //As of now, the only way to actually take damage is to press the ENTER button, I have it here to show that it is up, just not fully enabled with collisions with other objects.
       if (Input.GetKeyDown(KeyCode.Return)){
        Damage(20); //amount of damage taken
       } 
    }

    // private void hurt(Collider2D collision){

    //     if(collision.tag == "Enemy"){
    //         Damage(20);
    //     }
    // }

    
    //The Damage function to reduce the current health with how much percent of their health they have left.

    public void Damage(float damage){
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / 100f; 
    }


}
