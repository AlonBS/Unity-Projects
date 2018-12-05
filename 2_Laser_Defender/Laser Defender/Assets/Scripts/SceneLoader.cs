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
        FindObjectOfType<GameScore>().ResetGame();

    }

    public void LoadGameOver()
    {
        StartCoroutine(LoadGameOverScene());
        
    }

    private IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GameOver"); // SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
     
	
}
