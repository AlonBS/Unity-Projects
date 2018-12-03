using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject {

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numOfEnemies = 5;
    [SerializeField] float enemyMoveSpeed = 2f;


    public GameObject EnemyPrefab
    {
        get { return enemyPrefab; }
        
    }

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;

    }

    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();

        foreach (Transform t in pathPrefab.transform)
        {
            waveWaypoints.Add(t);
        }

        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }

    public float GetSpawnRandomFactor() { return spawnRandomFactor; }

    public int GetNumOfEnemies() { return numOfEnemies; }

    public float GetEnemyMoveSpeed() { return enemyMoveSpeed; }

}
