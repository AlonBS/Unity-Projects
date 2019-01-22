using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    [Tooltip("Our Level Timer In Seconds")]
    [SerializeField] float levelTime = 10;

    private Slider slider;


    private bool timeElapsed = false;
        

    private void Start()
    {
        this.slider = GetComponent<Slider>();
    }


    // Update is called once per frame
    void Update () {

        if (timeElapsed)
            return;

        slider.value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = Time.timeSinceLevelLoad >= levelTime;
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().AlertTimerFinished();
            timeElapsed = true;
        }


    }
}
