using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private GameObject[] spawners;

    public GameObject[] Spawners => spawners;
    public GameObject[] EnemyPrefabs => enemyPrefabs;
    private int oldWave = 0;
    public int Wave => oldWave;
    public int[] waveEnemyNumber;

    private void Awake()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
    }
}
