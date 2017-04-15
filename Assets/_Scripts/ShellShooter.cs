// Author(s): Paul Calande
// Class that shoots shells.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellShooter : MonoBehaviour
{
    [Tooltip("Shell prefab.")]
    public GameObject prefabShell;
    [Tooltip("The force at which the shell is launched.")]
    public float launchForce;
    [Tooltip("Number of seconds between each shot.")]
    public float fireRate;

    public void FireShell()
    {
        GameObject shell = Instantiate(prefabShell, transform.position, transform.rotation);
        Rigidbody rb = shell.GetComponent<Rigidbody>();
        rb.AddForce(transform.rotation * Vector3.forward * launchForce, ForceMode.Impulse);
    }

    private void Start()
    {
        StartCoroutine(ShellSpam());
    }

    IEnumerator ShellSpam()
    {
        while (true)
        {
            FireShell();
            yield return new WaitForSeconds(fireRate);
        }
    }
}