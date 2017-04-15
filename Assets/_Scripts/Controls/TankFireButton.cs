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
        compSnapZone.ObjectSnappedToDropZone += VRTK_SnapDropZone_ObjectSnappedToDropZone;
        compSnapZone.ObjectUnsnappedFromDropZone += VRTK_SnapDropZone_ObjectUnsnappedFromDropZone;
    }

    private void VRTK_SnapDropZone_ObjectSnappedToDropZone(object sender, SnapDropZoneEventArgs e)
    {
        Debug.Log("ObjectSnappedToDropZone");
        GameObject obj = e.snappedObject;
        if (obj.tag == "ShellCasing")
        {
            isShellCasingSnapped = true;
            shellCasing = obj;
        }
    }

    private void VRTK_SnapDropZone_ObjectUnsnappedFromDropZone(object sender, SnapDropZoneEventArgs e)
    {
        Debug.Log("ObjectUnsnappedFromDropZone");
        isShellCasingSnapped = false;
    }

    public void Press()
    {
        if (isShellCasingSnapped)
        {
            // Fire the shell!
            shellCasing.GetComponent<ShellCasing>().Fire(instanceShellEmitter);
        }
        else
        {
            if (soundFailure != null)
            {
                compAudio.PlayOneShot(soundFailure);
            }
        }
    }
}