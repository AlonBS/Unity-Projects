using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour {

    private const string MASTER_VOLUME_KEY = "master volume";
    private const string DIFFICULTY_KEY = "difficulty";

    private const float MIN_VOLUME = 0f, MAX_VOLUME = 1f;
    private const float MIN_DIFFICULTY = 0f, MAX_DIFFICULTY = 2f;


    public static void SetMasterVolume(float volume)
    {
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, Mathf.Clamp(volume, MIN_VOLUME, MAX_VOLUME));
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetDifficulty(float difficulty)
    {
        PlayerPrefs.SetFloat(DIFFICULTY_KEY, Mathf.Clamp(difficulty, MIN_DIFFICULTY, MAX_DIFFICULTY));
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }



}
