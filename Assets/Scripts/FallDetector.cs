using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDetector : MonoBehaviour {

    public float maxDistance;
    public GameObject player;
    
    private float y;

	void Start () {
        // Find the lowest y coordinate
        GameObject[] gameObjects = GameObject.FindObjectsOfType<GameObject>();
        y = gameObjects[0].transform.position.y;

        foreach (GameObject obj in gameObjects)
        {
            if (obj.transform.position.y < y)
                y = obj.transform.position.y;
        }
	}
	
	void LateUpdate () {
		// Check if player has fallen
        if (y - player.transform.position.y > maxDistance)
        {
            // Reset scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}
