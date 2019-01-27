using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {


    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;

    AttackerSpawner laneSpawner;
    Animator animator;

    private GameObject projectileParent;
    private const string PROJECTILE_PARENT_NAME = "Projectiles";

	// Use this for initialization
	void Start () {

        SetLaneSpawner();

        animator = GetComponent<Animator>();

        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
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
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, gun.transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }


}
