// Author(s): Paul Calande
// Button class.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFireButton : MonoBehaviour
{
    [Tooltip("Button sound for failure to fire shell.")]
    public AudioClip soundFailure;

    // Component references.
    private AudioSource compAudio;

    private void Awake()
    {
        compAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Controller")
        {
            Press();
        }
    }

    private void Press()
    {
        compAudio.PlayOneShot(soundFailure);
    }
}