// Author(s): Paul Calande
// Shell casing script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellCasing : MonoBehaviour
{
    [Tooltip("Shell prefab to instantiate upon firing.")]
    public GameObject prefabShell;
    [Tooltip("Casing prefab to instantiate upon firing.")]
    public GameObject prefabCasing;
    [Tooltip("The shell emitter instance. This is the object from which the shell is fired.")]
    public GameObject instanceShellEmitter;

    // Separate the shell and the casing.
    public void Fire()
    {
        // Fire the shell.
        GameObject shell = Instantiate(prefabShell, instanceShellEmitter.transform.position, instanceShellEmitter.transform.rotation);
        shell.transform.localScale = transform.localScale;
        // Leave behind a casing.
        GameObject casing = Instantiate(prefabCasing, transform.position, transform.rotation);
        casing.transform.localScale = transform.localScale;
        // Destroy this object.
        Destroy(gameObject);
    }
}