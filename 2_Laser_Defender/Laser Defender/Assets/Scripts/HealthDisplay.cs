using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {

    private Player player;
    private Text score;

    // Use this for initialization
    void Start()
    {

        this.player = FindObjectOfType<Player>();
        score = this.gameObject.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {

        if (this.player)
        {
            score.text = this.player.GetHealth().ToString();
        }
        else
        {
            score.text = "0";
        }


    }
}
