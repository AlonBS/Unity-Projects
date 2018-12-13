using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour {

    [SerializeField] int currentNumOfStars = 100;

    Text starsText;

	// Use this for initialization
	void Start () {

        starsText = GetComponent<Text>();
        UpdateDisplay();
    }


    private void UpdateDisplay()
    {
        starsText.text = currentNumOfStars.ToString();
    }


    public void AddStars(int ammount)
    {
        currentNumOfStars += ammount;
        UpdateDisplay();
    }

    public void SpendStars(int ammount)
    {
        if (ammount <= currentNumOfStars)
        {
            currentNumOfStars -= ammount;
            UpdateDisplay();
        }
    }
}
