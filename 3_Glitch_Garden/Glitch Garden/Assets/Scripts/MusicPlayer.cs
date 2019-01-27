using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {

        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(StartMusic());

    }

    private IEnumerator StartMusic()
    {
        yield return new WaitForSeconds(2);
        audioSource.Play();
        audioSource.volume = PlayerSettings.GetMasterVolume();
    }


    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }


}	
