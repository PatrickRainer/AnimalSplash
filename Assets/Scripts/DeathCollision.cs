using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollision : MonoBehaviour
{
    // GameController from the Scene
    public GameObject gameController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Is an enemy walked into my trigger?
        if (collision.gameObject.tag=="Enemy")
        {
            // ... then stop the game
            StopGame();
        }
    }

    // Stopp the Game
    void StopGame()
    {
        // Stopp spawning
        gameController.SendMessage("StopSpawning");

        // Show the GameOver-Menue
        gameController.SendMessage("ShowHighscore");

        // Stopp the Touch and Mouse input reading
        gameController.SendMessage("StopInputChecking");

        // Search for all Ghosts
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");

        // Go trough every Ghost and stop them
        foreach (GameObject current in gos)
        {
            current.SendMessage("StopMoving");
        }
    }
}
