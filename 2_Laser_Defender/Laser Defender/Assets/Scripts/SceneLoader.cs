using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {


    public void MainMenu()
    {
        SceneManager.LoadScene("Start"); // SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game"); // SceneManager.LoadScene(1);

    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver"); // SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
     
	
}
