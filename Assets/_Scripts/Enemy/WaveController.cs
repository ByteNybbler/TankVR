// Author(s): Paul Calande
// Wave controller script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [Tooltip("Enemy tank prefab.")]
    public GameObject prefabEnemyTank;
    [Tooltip("Number of seconds between enemy spawns.")]
    public float timeBetweenSpawns;

    // List of enemy tanks.
    private List<GameObject> enemies = new List<GameObject>();
    // List of enemy spawn points.
    private List<Transform> enemySpawnPoints = new List<Transform>();
    // The current wave.
    private int wave = 0;
    // Number of enemies to spawn in this wave.
    private int enemiesInThisWave = 0;
    // Number of enemies killed so far in this wave.
    private int enemiesKilledThisWave = 0;
    // Number of enemies spawned so far in this wave.
    private int enemiesSpawnedThisWave = 0;

    // Component references.
    private KeyPoints compKeyPoints;

    private void Awake()
    {
        compKeyPoints = GetComponent<KeyPoints>();
    }

    private void Start()
    {
        enemySpawnPoints = compKeyPoints.GetKeyPoints();
    }

    private Transform GetRandomSpawnPoint()
    {
        return enemySpawnPoints[Random.Range(0, enemySpawnPoints.Count)];
    }

    private void CreateTank()
    {
        Transform spawnPoint = GetRandomSpawnPoint();
        GameObject tank = Instantiate(prefabEnemyTank, spawnPoint.position, spawnPoint.rotation);
        tank.GetComponent<Tank>().Died += EnemyTank_Died;
    }

    // Enemy tank death event payload.
    private void EnemyTank_Died(GameObject tank)
    {
        enemies.Remove(tank);
        ++enemiesKilledThisWave;
        if (enemiesKilledThisWave == enemiesInThisWave)
        {
            // Go to next wave.
            StartWave();
        }
    }

    private void StartWave()
    {
        ++wave;
        enemiesKilledThisWave = 0;
        enemiesSpawnedThisWave = 0;
        // Increase the number of enemies per wave by one.
        enemiesInThisWave = Mathf.CeilToInt((float)wave / 5);
        StartCoroutine(SpawnStuff());
    }

    IEnumerator SpawnStuff()
    {
        while (enemiesSpawnedThisWave != enemiesInThisWave)
        {
            ++enemiesSpawnedThisWave;
            CreateTank();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    public int GetWave()
    {
        return wave;
    }
}