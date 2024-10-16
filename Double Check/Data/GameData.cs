using UnityEngine;
using System;

[Serializable]
public class GameData
{
    public int lastPlayedSceneIndex;
    public Vector3 playerPosition;
    public float playerHealth;

    // Constructor to initialize with default values
    public GameData()
    {
        lastPlayedSceneIndex = 0;
        playerPosition = Vector3.zero;
        playerHealth = 100f; // Or whatever your default max health is
    }
}

