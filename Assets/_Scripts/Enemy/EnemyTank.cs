// Author(s): Paul Calande
// Enemy tank script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTank : MonoBehaviour
{
    // Component references.
    NavMeshAgent compAgent;

    private void Awake()
    {
        compAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Aim at player.
    }
}