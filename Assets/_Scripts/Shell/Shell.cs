// Author(s): Paul Calande
// Shell script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [Tooltip("The force at which the shell is fired.")]
    public float launchForce;
    [Tooltip("Sound played when the shell is fired.")]
    public AudioClip soundFire;

    // Component references.
    private Rigidbody compRigidbody;
    private AudioSource compAudio;

    private void Awake()
    {
        compRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Fire();
    }

    // Fire the shell.
    public void Fire()
    {
        compRigidbody.AddForce(transform.rotation * Vector3.forward * launchForce, ForceMode.Impulse);
        // Play firing sound.
        compAudio.PlayOneShot(soundFire);
    }
}