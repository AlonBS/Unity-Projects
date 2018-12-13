using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {


    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, gun.transform.rotation);
        Debug.Log("FIRE!");
        return;

        

    }


}
