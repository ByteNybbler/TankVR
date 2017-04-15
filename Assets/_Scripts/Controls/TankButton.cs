// Author(s): Paul Calande
// Button class.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankButton : MonoBehaviour
{
    public AudioClip soundSuccessful;

    // Component references.
    private AudioSource compAudio;

    private void Awake()
    {
        compAudio = GetComponent<AudioSource>();
    }
}