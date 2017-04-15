// Author(s): Paul Calande
// Script for Vive controller stuff.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TankFireButton")
        {
            Debug.Log("CONTROLLER OMG");
            other.GetComponent<TankFireButton>().Press();
        }
    }
}