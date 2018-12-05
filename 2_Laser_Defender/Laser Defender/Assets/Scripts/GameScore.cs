using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour {

    private int score = 0;

    // Use this for initialization
    void Awake()
    {

        SetUpSingleton();

    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }


    public int Score
    {
        get { return score; }
    }


    public void AddToScore(int points)
    {
        this.score += points;
        Debug.Log("HERE2");
    }

    public void ResetGame()
    {
        Destroy(this.gameObject);
    }

}
