using System.Collections;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] private int currentWave = 0;
    public int CurrentWave => currentWave;
    public float spawnDelay = 3;

    private void Update()
    {
        // Debug.Log("Wave: " + currentWave + " Enemies: " + WorldEnemyCounter());

        if (WorldEnemyCounter() <= 0)
        {
            // currentWave++;
            StartCoroutine(DelayWaveChange());
            currentWave++;

        }
    }
    private int WorldEnemyCounter()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    IEnumerator DelayWaveChange()
    {
        yield return new WaitForSeconds(spawnDelay);


    }
}