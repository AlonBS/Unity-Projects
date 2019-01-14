using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {


    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;

    AttackerSpawner laneSpawner;
    Animator animator;

	// Use this for initialization
	void Start () {

        SetLaneSpawner();

        animator = GetComponent<Animator>();

        
	}

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner sp in spawners)
        {
            if  (Mathf.Abs(sp.transform.position.y - this.transform.position.y) <= Mathf.Epsilon)
            {
                laneSpawner = sp;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
	}


    private bool IsAttackerInLane()
    {
        return laneSpawner.transform.childCount > 0;
    }


    public void Fire()
    {
        Debug.Log("HERUEHRUIAEHR");
        Instantiate(projectile, gun.transform.position, gun.transform.rotation);
    }


}
