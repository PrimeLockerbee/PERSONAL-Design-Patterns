using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string name;
        public int count;
        public float rate;
    }

    protected enum SpawnFSM
    {
        counting,
        waiting,
        spawning
    }

    [SerializeField] GameObject go_SpawnPointRed;
    [SerializeField] GameObject go_SpawnPointBlue;
    [SerializeField] GameObject go_SpawnPointYellow;

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    SpawnFSM spawnMode = SpawnFSM.counting;

    private void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnBlue();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpawnYellow();
        }

        DoWave();

        Debug.Log(spawnMode);
    }

    protected void DoWave()
    {
        switch (spawnMode)
        {
            case SpawnFSM.counting:
                waveCountdown -= Time.deltaTime;

                if (waveCountdown <= 0)
                {
                    spawnMode = SpawnFSM.spawning;
                }

                break;
            case SpawnFSM.waiting:
                if(!EnemyIsAlive())
                {
                    WaveCompleted();
                }
                else
                {
                    return;
                }
                break;
            case SpawnFSM.spawning:

                 if(spawnMode == SpawnFSM.spawning)
                 {
                    StartCoroutine(SpawnWave(waves[nextWave]));
                 }
                break;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");
         
        spawnMode = SpawnFSM.counting;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("All Waves Complete!!");
        }
        else
        {
            nextWave++;
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;

        //SEARCHES FOR ALIVE ENEMIES
        if(searchCountdown <= 0)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("RedEnemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);

        spawnMode = SpawnFSM.spawning;

        //DO SPAWNING
        for(int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        spawnMode = SpawnFSM.waiting;

        yield break;
    }

    void SpawnEnemy()
    {
        GameObject EnemyRed = ObjectPooler.SharedInstance.GetPooledObject("RedEnemy");

        EnemyRed.transform.position = go_SpawnPointRed.transform.position;
        EnemyRed.transform.rotation = go_SpawnPointRed.transform.rotation;
        EnemyRed.SetActive(true);

        Debug.Log("Spawning Enemy: " + EnemyRed.name);
    }

    void SpawnBlue()
    {
        GameObject EnemyRed = ObjectPooler.SharedInstance.GetPooledObject("BlueEnemy");

        EnemyRed.transform.position = go_SpawnPointBlue.transform.position;
        EnemyRed.transform.rotation = go_SpawnPointBlue.transform.rotation;
        EnemyRed.SetActive(true);
    }

    void SpawnYellow()
    {
        GameObject EnemyRed = ObjectPooler.SharedInstance.GetPooledObject("YellowEnemy");

        EnemyRed.transform.position = go_SpawnPointYellow.transform.position;
        EnemyRed.transform.rotation = go_SpawnPointYellow.transform.rotation;
        EnemyRed.SetActive(true);
    }
}
