// Author(s): Paul Calande
// Tank fire button class.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class TankFireButton : MonoBehaviour
{
    [Tooltip("Button sound for failure to fire shell.")]
    public AudioClip soundFailure;
    [Tooltip("The snap zone object.")]
    public GameObject snapZone;
    [Tooltip("The shell emitter instance. This is the object from which the shell is fired.")]
    public GameObject instanceShellEmitter;

    // Whether a shell casing is currently snapped.
    private bool isShellCasingSnapped = false;
    // The current shell casing in the turret.
    private GameObject shellCasing;

    // Component references.
    private AudioSource compAudio;
    private VRTK_SnapDropZone compSnapZone;

    private void Awake()
    {
        compAudio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        compSnapZone = snapZone.GetComponent<VRTK_SnapDropZone>();
        compSnapZone.ObjectEnteredSnapDropZone += VRTK_SnapDropZone_ObjectEnteredSnapDropZone;
        compSnapZone.ObjectExitedSnapDropZone +=
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Controller")
        {
            Press();
        }
    }

    private void VRTK_SnapDropZone_ObjectEnteredSnapDropZone(object sender, SnapDropZoneEventArgs e)
    {
        GameObject obj = e.snappedObject;
        if (obj.tag == "ShellCasing")
        {
            isShellCasingSnapped = true;
            shellCasing = obj;
        }
    }

    private void VRTK_SnapDropZone_ObjectExitedSnapDropZone(object sender, SnapDropZoneEventArgs e)
    {
        isShellCasingSnapped = false;
    }

    private void Press()
    {
        if (isShellCasingSnapped)
        {
            // Fire the shell!
            shellCasing.GetComponent<ShellCasing>().Fire(instanceShellEmitter);
        }
        else
        {
            compAudio.PlayOneShot(soundFailure);
        }
    }
}