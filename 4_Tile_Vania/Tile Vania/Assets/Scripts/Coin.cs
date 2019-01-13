using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    [SerializeField] AudioClip coinPickUpSFX;
    [SerializeField] float volume = 0.5f;

    [SerializeField] int pointsValue = 100;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position, volume);

        FindObjectOfType<GameSession>().AddToScore(pointsValue);

        Destroy(gameObject);
    }


}
