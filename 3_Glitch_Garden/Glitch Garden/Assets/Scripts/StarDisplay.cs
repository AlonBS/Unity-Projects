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


    public bool HaveEnoughStars(int amount)
    {
        return amount <= currentNumOfStars;
    }


    public void AddStars(int amount)
    {
        currentNumOfStars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        if (amount <= currentNumOfStars)
        {
            currentNumOfStars -= amount;
            UpdateDisplay();
        }
    }
}
