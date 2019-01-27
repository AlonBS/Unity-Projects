using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    private GameObject currentTarget;
    private float currentSpeed = 1f;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        LevelController lc = FindObjectOfType<LevelController>();
        if (lc)
        {
            lc.AttackerKilled();
        }
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
