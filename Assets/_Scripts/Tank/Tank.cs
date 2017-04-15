// Author(s): Paul Calande
// Tank script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [Tooltip("Damage sound.")]
    public AudioClip soundDamage;

    public delegate void DiedHandler(GameObject obj);
    public event DiedHandler Died;

    // Component references.
    private Health compHealth;
    private AudioSource compAudio;

    private void Awake()
    {
        compHealth = GetComponent<Health>();
        compAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Shell")
        {
            compHealth.Damage(1f);
            Destroy(other.gameObject);
            // Play damage sound.
            compAudio.PlayOneShot(soundDamage);
        }
    }

    private void OnEnable()
    {
        compHealth.Died += Health_Died;
    }
    private void OnDisable()
    {
        compHealth.Died -= Health_Died;
    }

    private void Die()
    {
        OnDied(gameObject);
        Destroy(gameObject);
    }

    private void Health_Died()
    {
        Die();
    }

    private void OnDied(GameObject obj)
    {
        if (Died != null)
        {
            Died(obj);
        }
    }
}