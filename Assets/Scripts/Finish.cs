using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//I looked up on the Unity forum on this.
public class Finish : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision){

        if(collision.tag == "Player"){

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }


}
