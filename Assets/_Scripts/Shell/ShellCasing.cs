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

    // Separate the shell and the casing; fire the shell from the shell emitter.
    public void Fire(GameObject instanceShellEmitter)
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