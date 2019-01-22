using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [SerializeField] int health = 100;

    [Header("Effects")]
    //[SerializeField] AudioClip deathSound;
    [SerializeField] float soundVolume = 1f;
    //[SerializeField] GameObject deathExplosion;

    private GameObject currentTarget;
    

    private float currentSpeed = 1f;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        FindObjectOfType<LevelController>().AttackerKilled();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
        ResumeWalking();
    }

    public void SetMovementSpeed(float speed)
    {
        this.currentSpeed = speed;
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



    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(int damage)
    {
        if (!currentTarget)
        {
            return;
        }

        Health health = currentTarget.GetComponent<Health>();
        if (health != null)
        {
            health.DealDamage(damage);
            
        }
    }

    private void ResumeWalking()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

   



}
