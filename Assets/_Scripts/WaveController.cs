// Author(s): Paul Calande
// Wave controller script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [Tooltip("Enemy prefab.")]
    public GameObject prefabEnemy;

    // List of enemy tanks.
    private List<GameObject> enemies = new List<GameObject>();
    // List of enemy spawn points.
    private List<Transform> enemySpawnPoints = new List<Transform>();

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

    private void CreateTank()
    {
        //GameObject tank = Instantiate(prefabEnemy,)
    }

    private void EnemyTank_Died(GameObject tank)
    {
        enemies.Remove(tank);
    }
}