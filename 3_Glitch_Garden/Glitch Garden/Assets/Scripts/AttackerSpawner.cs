using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

    [SerializeField] float minSpawnTime = 1f, maxSpawnTime = 5f;
    [SerializeField] Attacker attackerPrefab;

    private bool spawning = true;

	// Use this for initialization

	IEnumerator Start () {

        while (spawning)
        {

            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            SpawnAttacker();

        }
		
	}


    private void SpawnAttacker()
    {
        //Vector3 newPos = transform.position;
        //newPos.y -= Random.Range(0, 4);

        Attacker newAttacker = Instantiate(attackerPrefab, transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
