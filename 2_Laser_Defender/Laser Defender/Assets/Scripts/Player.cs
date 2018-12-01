using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;


    private float xMin, xMax, yMin, yMax;

	// Use this for initialization
	void Start () {

        SetupMoveBoundaries();

       


		
	}

    private IEnumerator PrintShit()
    {
        for (;;)
        {
            Debug.Log("Hello");
            yield return new WaitForSeconds(3f);
           // Debug.Log("World");
        }
        

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
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

        }




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
