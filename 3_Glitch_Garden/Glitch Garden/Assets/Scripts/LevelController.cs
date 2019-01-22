using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    private int numOfEnemies = 0;
    private bool timerFinished = false;

	// Use this for initialization
	void Start () {
		
	}
	

    public void AttackerSpawned()
    {
        ++numOfEnemies;
    }

    public void AttackerKilled()
    {
        --numOfEnemies;
        if (timerFinished && numOfEnemies <= 0)
        {
            Debug.Log("LEVEL END");
        }
    }

    public void AlertTimerFinished()
    {
        timerFinished = true;
        foreach (AttackerSpawner a in FindObjectsOfType<AttackerSpawner>())
        {
            a.StopSpawning();
        }
        
    }
}
