using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    // Serializable fields
    [SerializeField] float speed = 1f;


    private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {

        rigidBody = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {

        if (FacingRight())
        {
            rigidBody.velocity = Vector2.right * speed;
        }
        else
        {
            rigidBody.velocity = Vector2.left * speed;
        }
	}

    private bool FacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //speed *= -1;
        //transform.localScale = new Vector2(Mathf.Sign(speed), transform.localScale.y);

            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //speed *= -1;
        transform.localScale = new Vector2(-Mathf.Sign(rigidBody.velocity.x), 1f);
    }
}
