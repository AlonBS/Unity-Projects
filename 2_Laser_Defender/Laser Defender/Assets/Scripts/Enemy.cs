using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] float health = 100f;
    [SerializeField] float shotCounter = 1f;
    [SerializeField] float minTimeBetweenShots = .2f;
    [SerializeField] float maxTimeBetweenShots = 3f;

    [SerializeField] GameObject enemyLaserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] GameObject explosion;
    
    [Header("Sounds")]
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0,1)] float soundLevel = 1f;
    [SerializeField] AudioClip projectileSound;
    [SerializeField] [Range(0, 1)] float projectileSoundLevel = 1f;
    

    // Use this for initialization
    void Start () {

        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
		
	}
	
	// Update is called once per frame
	void Update () {

        CountDownAndShoot();
		
	}

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }

    }

    private void Fire()
    {
        var laser = Instantiate(enemyLaserPrefab.gameObject, transform.position, Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -projectileSpeed);

        AudioSource.PlayClipAtPoint(projectileSound, Camera.main.transform.position, projectileSoundLevel);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (damageDealer)
        {
            ProcessHit(damageDealer);
        }

    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.Damage;
        if (health <= 0f)
        {
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, soundLevel);

            var explosionObj = Instantiate(explosion.gameObject, transform.position, Quaternion.identity);
            Destroy(explosionObj, 1f);
            Destroy(gameObject);

        }
        damageDealer.Hit();
    }
}
