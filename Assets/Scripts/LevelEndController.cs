using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEndController : MonoBehaviour {

    public Text gemCount;
    public Text time;
    public Text nextLevel;

	void Start () {
        gemCount.text = LevelStatistics.gemsCollected + " / " + LevelStatistics.gemsInLevel;
        time.text = System.Math.Round(LevelStatistics.completionTime, 2).ToString();

        // Disable next level button if no next level
        if (LevelStatistics.nextLevel < 0)
        {
            Destroy(nextLevel.gameObject);
        }

	}

    public void MainMenuPress()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevelPress()
    {
        SceneManager.LoadScene(LevelStatistics.nextLevel);
    }

    public void RetryPress()
    {
        SceneManager.LoadScene(LevelStatistics.thisLevel);
    }
}
