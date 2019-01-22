using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

    [SerializeField] float minSpawnTime = 1f, maxSpawnTime = 5f;
    [SerializeField] Attacker[] attackersPrefabs;

    private bool spawning = true;

	// Use this for initialization

	IEnumerator Start () {

        while (spawning)
        {

            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            SpawnAttacker();

        }
		
	}


    public void StopSpawning()
    {
        spawning = false;
    }


    private void SpawnAttacker()
    {
        Spawn(Random.Range(0, attackersPrefabs.Length));
    }

    private void Spawn(int attackerIndex)
    {
        Attacker newAttacker = Instantiate(attackersPrefabs[attackerIndex], transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
