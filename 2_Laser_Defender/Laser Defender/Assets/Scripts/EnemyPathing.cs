using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {


    private WaveConfig waveConfig;
    private List<Transform> waypoints;
    private int waypointIndex = 0;

	// Use this for initialization
	void Start () {


        waypoints = waveConfig.GetWaypoints();

        //Debug.Log(transform.position);
        //Debug.Log(FindObjectOfType<EnemyPathing>().gameObject.GetComponent<EnemyPathing>().gameObject.transform.position);

        // This is how you populate the list programmatically 
        /*
        waypoints = new List<GameObject>();
        GameObject path = GameObject.Find("Path(0)");
        for (int i = 0; i < path.transform.childCount; ++i)
        {
            waypoints.Add(path.transform.GetChild(i).gameObject);
        }
        */

        // Transform Enemy to the first waypoint 
        transform.position = waypoints[waypointIndex].transform.position;
    }

	
	// Update is called once per frame
	void Update () {

        MoveEnemy();
		
	}


    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void MoveEnemy()
    {
        if (waypointIndex < waypoints.Count)
        {
            var targetPos = waypoints[waypointIndex].transform.position;
            var movmentThisFrame = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPos, movmentThisFrame);

            if (transform.position == targetPos)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }

        

    }
}
