// Author(s): Paul Calande
// Wave controller script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    // List of enemy tanks.
    private List<GameObject> enemies = new List<GameObject>();

    private void EnemyTank_Died(GameObject tank)
    {
        enemies.Remove(tank);
    }
}