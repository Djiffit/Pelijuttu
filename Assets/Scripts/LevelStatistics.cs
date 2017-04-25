using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStatistics : MonoBehaviour {
    static public float completionTime;
    static public int gemsCollected;
    static public int thisLevel;
    static public int gemsInLevel;

    // set to -1 if no next level
    static public int nextLevel;
}
