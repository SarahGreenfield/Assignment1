//Using a YouTube Tutorial playlist link: https://www.youtube.com/watch?v=TcranVQUQ5U&list=PLgOEwFbvGm5o8hayFB6skAfa8Z-mw4dPV 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Room camera
    [SerializeField] private float cameraSpeed; //able to control the speed of the camera in Unity
    private float currentPosX; //tell the camera where to go
    private Vector3 velocity = Vector3.zero;

    //Follow player
    [SerializeField] private Transform player;

    private void Update(){
        // transform.position = Vector3.SmoothDamp(transform.position, 
        //                      new Vector3(currentPosX, transform.position.y, transform.position.z), 
        //                      ref velocity, cameraSpeed * Time.deltaTime);

        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }

}
