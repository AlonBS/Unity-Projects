using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject looseLabel;
    [SerializeField] AudioClip winFX;
    [SerializeField] AudioClip looseFX;

    private int numOfEnemies = 0;
    private bool timerFinished = false;


	// Use this for initialization
	void Start () {

        winLabel.SetActive(false);
        looseLabel.SetActive(false);
        
    }
	

    public void AttackerSpawned()
    {
        ++numOfEnemies;
    }

    public void AttackerKilled()
    {
        --numOfEnemies;
        if (timerFinished && numOfEnemies <= 0)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    public void AlertTimerFinished()
    {
        timerFinished = true;
        foreach (AttackerSpawner a in FindObjectsOfType<AttackerSpawner>())
        {
            a.StopSpawning();
        }
    }

    private IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        Time.timeScale = 0;

        yield return new WaitForSeconds(10);

        GetComponent<SceneLoader>().LoadNextScene();
    }

    public void HandleLooseLevel()
    {
        looseLabel.SetActive(true);

        Time.timeScale = 0;
        
        //yield return new WaitForSeconds(3);

    }
}
