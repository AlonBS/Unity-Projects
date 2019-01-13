using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {

    [SerializeField] int playerLives = 3;
    private int score = 0;
    
    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;




    private void Awake()
    {
        int numOfInstances = FindObjectsOfType<GameSession>().Length;
        if (numOfInstances > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    // Use this for initialization
    void Start () {

        updateUI();
    }

    private void updateUI()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }


    public void ProcessPlayerDeath()
    {
        
        if (playerLives > 1)
        {
            playerLives--;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            updateUI();
        }
        else
        {
            ResetSession();
        }


    }

    private void ResetSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }


    public void AddToScore(int ammount)
    {
        score += ammount;
        updateUI();
    }
	
}
