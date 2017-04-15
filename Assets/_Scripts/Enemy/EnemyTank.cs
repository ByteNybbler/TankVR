// Author(s): Paul Calande
// Enemy tank script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{
    public delegate void DiedHandler(GameObject obj);
    public event DiedHandler Died;

    private void Die()
    {
        OnDied(gameObject);
        Destroy(gameObject);
    }

    private void OnDied(GameObject obj)
    {
        if (Died != null)
        {
            Died(obj);
        }
    }
}