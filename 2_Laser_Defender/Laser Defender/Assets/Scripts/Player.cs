using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] int health = 500;
    [SerializeField] GameObject explosion;

    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;

    [Header("Sounds")]
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0,1)] float soundLevel = 1f;
    [SerializeField] AudioClip projectileSound;
    [SerializeField] [Range(0, 1)] float projectileSoundLevel = 1f;
    
    

    private float xMin, xMax, yMin, yMax;
    private Coroutine firingCoroutine;


    // Use this for initialization
    void Start () {

        SetupMoveBoundaries();
	}

   
       

    // Update is called once per frame
    void Update () {

        Move();
        Fire();
    }

    private void Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = transform.position.x + deltaX;
        var newYPos = transform.position.y + deltaY;

        transform.position = new Vector2(Mathf.Clamp(newXPos, xMin, xMax), Mathf.Clamp(newYPos, yMin, yMax));
    }


    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
        
    }

    private IEnumerator FireContinuously()
    {
        
        for (;;) {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

            AudioSource.PlayClipAtPoint(projectileSound, Camera.main.transform.position, projectileSoundLevel);

            yield return new WaitForSeconds(projectileFiringPeriod);
        }
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
        if (health <= 0)
        {
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, soundLevel);
            var explosionObj = Instantiate(explosion.gameObject, transform.position, Quaternion.identity);
            Destroy(explosionObj, 1f);
            Destroy(gameObject);

            FindObjectOfType<SceneLoader>().LoadGameOver();
        }
        damageDealer.Hit();
    }



    public int GetHealth()
    {
        return health;
    }




    private void SetupMoveBoundaries()
    {
        Vector3 mins = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxs = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 1));

        xMin = mins.x + padding;
        yMin = mins.y + padding;

        xMax = maxs.x - padding;
        yMax = maxs.y - padding;

    }
}
