using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    [SerializeField] int waitTime = 4;

	// Use this for initialization
	void Start () {

        
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine(LoadStartScene());
        }
	}

	// Update is called once per frame
	void Update () {
		
	}


    private IEnumerator LoadStartScene()
    {

        yield return new WaitForSeconds(waitTime);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
