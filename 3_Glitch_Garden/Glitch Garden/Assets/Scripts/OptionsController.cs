using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {


    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.8f;

    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDifficulty = 1f;

    // Difficulty assad dddds 

    private MusicPlayer musicPlayer;


    // Use this for initialization
    void Start()
    {
        volumeSlider.value = PlayerSettings.GetMasterVolume();
        musicPlayer = FindObjectOfType<MusicPlayer>();

        difficultySlider.value = PlayerSettings.GetDifficulty();
    }



    void Update()
    {
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No Music Player!");
        }
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }


    public void SaveSettings()
    {
        PlayerSettings.SetMasterVolume(volumeSlider.value);
        PlayerSettings.SetDifficulty(difficultySlider.value);
    }
	
}
