using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;

	// Use this for initialization
	void Start () {

        StartCoroutine(SpawnAllWaves());
    }

    private IEnumerator SpawnAllWaves()
    {
        Debug.Log("A");
        yield return new WaitForSeconds(1);
        Debug.Log("B");
        yield return new WaitForSeconds(1);
        Debug.Log("C");

        //for (int i = startingWave; i < waveConfigs.Count; ++i)
        //{

        //    yield return StartCoroutine(SpawnAllEnemiesInWave(waveConfigs[i]));

        //    //if (i < waveConfigs.Count - 1)
        //    //{
        //    //    i = startingWave;
        //    //}

        //}
    }

    private Object foo()
    {
        Debug.Log("D");
        new WaitForSeconds(5);
        return null;
    }


    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.GetNumOfEnemies(); ++i)
        {
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(),
                                       waveConfig.GetWaypoints()[0].transform.position,
                                       Quaternion.identity);

            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());

        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
