// Author(s): Paul Calande
// Make the object face the direction of the rigidbody's velocity... but only at a certain speed.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceRigidbodyDirectionWhenQuick : MonoBehaviour
{
    [Tooltip("How fast the rigidbody must be for the correction to take effect.")]
    public float requiredSpeed;

    // Component references.
    private Rigidbody compRigidbody;

    private void Awake()
    {
        compRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (compRigidbody.velocity != Vector3.zero && compRigidbody.velocity.magnitude > requiredSpeed)
        {
            transform.rotation = Quaternion.LookRotation(compRigidbody.velocity);
        }
    }
}