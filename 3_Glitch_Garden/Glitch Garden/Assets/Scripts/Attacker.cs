using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [SerializeField] int health = 100;

    [Header("Effects")]
    //[SerializeField] AudioClip deathSound;
    [SerializeField] float soundVolume = 1f;
    //[SerializeField] GameObject deathExplosion;
    

    private float currentSpeed = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
		
	}

    public void SetMovementSpeed(float speed)
    {
        this.currentSpeed = speed;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Here aaaaaaaaaaaaaaaa");

        //DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        //if (damageDealer)
        //{
        //    ProcessHit(damageDealer);
        //}
    }


    //private void HandleDeath()
    //{
    //    // Effects
    //    {
    //        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, soundVolume);
    //        //var explosionObj = Instantiate(explosion.gameObject, transform.position, Quaternion.identity);
    //        //Destroy(explosionObj, 1f);
    //        Destroy(gameObject);
    //    }

    //    // UI (Score)
    //    {
    //        //Debug.Log("HERE");
    //        //FindObjectOfType<GameScore>().AddToScore(pointsWhenKilled);
    //    }
    //}




}
