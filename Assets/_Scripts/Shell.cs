// Author(s): Paul Calande
// Shell script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [Tooltip("The force at which the shell is launched.")]
    public float launchForce;

    // Component references.
    private Rigidbody compRigidbody;

    private void Awake()
    {
        compRigidbody = GetComponent<Rigidbody>();
    }

    public void Fire()
    {
        compRigidbody.AddForce(transform.rotation * Vector3.forward * launchForce, ForceMode.Impulse);
    }
}