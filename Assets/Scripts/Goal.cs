using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Set all the statistics
            LevelStatistics.completionTime = Time.timeSinceLevelLoad;

            LevelStatistics.gemsCollected = other.gameObject.GetComponent<PlayerController>().GemCount;
            LevelStatistics.gemsInLevel = GameObject.FindGameObjectsWithTag("Gem").Length;

            LevelStatistics.thisLevel = SceneManager.GetActiveScene().buildIndex;
            LevelStatistics.nextLevel = SceneManager.GetActiveScene().buildIndex + 1; 

            // Check that scene index doesn't overflow
            if (LevelStatistics.nextLevel > SceneManager.sceneCountInBuildSettings - 1)
            {
                LevelStatistics.nextLevel = -1;
            }

            SceneManager.LoadScene("level_end");
        }
    }
}
