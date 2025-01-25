using System.Collections;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] private int currentWave = 0;
    public int CurrentWave => currentWave;
    public float waveChangeDelay = 3;
    private bool isWaveChanging = false;

    private void Update()
    {
        // Debug.Log("Wave: " + currentWave + " Enemies: " + WorldEnemyCounter());

        if (WorldEnemyCounter() <= 0 && !isWaveChanging)
        {
            // currentWave++;
            StartCoroutine(DelayWaveChange());

        }
    }
    private int WorldEnemyCounter()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    IEnumerator DelayWaveChange()
    {
        isWaveChanging = true; // Set flag agar tidak dipanggil lagi
        yield return new WaitForSeconds(waveChangeDelay); // Tunggu sesuai delay
        currentWave++;
        isWaveChanging = false; // Reset flag setelah selesai
    }
}