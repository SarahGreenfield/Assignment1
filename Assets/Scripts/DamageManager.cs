using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//making the damage manager for the player to take damage
public class DamageManager : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            collision.GetComponent<HealthManager>().Damage(damage);
        }
    }
}
