using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {

    private float timeBetweenLoads = 1f;
    private float slowMotion = 0.33f;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadNextScene());
    }



    private IEnumerator LoadNextScene()
    {
        Time.timeScale = slowMotion;

        yield return new WaitForSeconds(timeBetweenLoads);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
