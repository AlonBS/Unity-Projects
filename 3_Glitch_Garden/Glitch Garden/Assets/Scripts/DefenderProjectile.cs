using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderProjectile : MonoBehaviour {

    
    [SerializeField] float translationSpeed = 1f;
    [SerializeField] float rotationAngle = 5f;

    [SerializeField] int damage = 50;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //transform.Rotate(new Vector3(0, 0, 10f), rotationAngle * Time.deltaTime);

        transform.Translate(Vector2.right * Time.deltaTime * translationSpeed, Space.World);
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationAngle, Space.World);




    }

    public void OnTriggerEnter2D(Collider2D otherCollider)
    {

        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if (health && attacker)
        {
            health.DealDamage(damage);
            Destroy(gameObject);

        }

    }
}
