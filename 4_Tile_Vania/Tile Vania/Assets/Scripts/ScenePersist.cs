using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour {


    private int startingSceneIndex;

    private void Awake()
    {
        int numOfInstances = FindObjectsOfType<ScenePersist>().Length;
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

        startingSceneIndex = SceneManager.GetActiveScene().buildIndex;

    }


    private void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex != startingSceneIndex)
        {
            Destroy(gameObject);
        }
    }

}
