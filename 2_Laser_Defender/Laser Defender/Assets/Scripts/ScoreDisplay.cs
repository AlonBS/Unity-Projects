using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    private GameScore gameScore;
    private Text score;

	// Use this for initialization
	void Start () {

        this.gameScore = FindObjectOfType<GameScore>();
        score = this.gameObject.GetComponent<Text>();
        //score = this.gameObject.GetComponent("Score") as Text;

    }
	
	// Update is called once per frame
	void Update () {

        if (gameScore)
        {
            score.text = gameScore.Score.ToString();
        }
        else
        {
            score.text = "0";
        }


    }
}
