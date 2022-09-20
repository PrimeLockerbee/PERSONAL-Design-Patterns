using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] GameObject go_SpawnPointRed;
    [SerializeField] GameObject go_SpawnPointBlue;
    [SerializeField] GameObject go_SpawnPointYellow;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnRed();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnBlue();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpawnYellow();
        }

    }

    void SpawnRed()
    {
        GameObject EnemyRed = ObjectPooler.SharedInstance.GetPooledObject("RedEnemy");

        EnemyRed.transform.position = go_SpawnPointRed.transform.position;
        EnemyRed.transform.rotation = go_SpawnPointRed.transform.rotation;
        EnemyRed.SetActive(true);
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
