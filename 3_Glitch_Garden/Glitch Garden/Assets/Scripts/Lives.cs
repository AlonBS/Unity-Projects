using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour {


    [SerializeField] int numOfLives = 10;

    Text livesText;

    // Use this for initialization
    void Start()
    {

        livesText = GetComponent<Text>();
        UpdateDisplay();
    }


    private void UpdateDisplay()
    {
        livesText.text = numOfLives.ToString();
    }


    public void TakeLives(int amount)
    {
        numOfLives -= amount;
        UpdateDisplay();
        if (numOfLives < 0)
        {
            FindObjectOfType<SceneLoader>().LoadEndScene();
        }
    }

}
