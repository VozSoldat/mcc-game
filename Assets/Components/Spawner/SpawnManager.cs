using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private GameObject[] spawners;
    private int oldWave = 0;
    public int[] waveEnemyNumber;

    private void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
    }

    private void Update()
    {
        int currentWave = GetComponent<WaveController>().CurrentWave;
        Debug.Log("oldWave : " + oldWave + " currentWave : " + currentWave);
        if (currentWave != oldWave)
        {
            oldWave = currentWave;
            Spawn();
        }

    }

    private void Spawn()
    {
        Debug.Log("Spawning enemies");

        for (int i = 0; i < waveEnemyNumber[oldWave]; i++)
        {
            // Menghitung offset untuk menghindari tabrakan
            Vector3 offset = new Vector3(i * 1.5f, 1, 0); // Jarak antar musuh
            GameObject spawnPoint = spawners[Random.Range(0, spawners.Length)];
            Vector3 spawnPosition = spawnPoint.transform.position + offset;

            Instantiate(
                enemyPrefabs[Random.Range(0, enemyPrefabs.Length)],
                spawnPosition,
                spawnPoint.transform.rotation
            );
        }
    }
}
