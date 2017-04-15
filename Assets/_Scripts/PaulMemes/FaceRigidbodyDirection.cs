// Author(s): Paul Calande
// Make the object face the direction of the rigidbody's velocity.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceRigidbodyDirection : MonoBehaviour
{
    // Component references.
    private Rigidbody compRigidbody;

    private void Awake()
    {
        compRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(compRigidbody.velocity);
    }
}