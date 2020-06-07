using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    private void Start()
    {
        SetKinematic(true);
    }
    public void Die()
    {
        SetKinematic(false);
        GetComponent<Animator>().enabled = false;
    }
    private void SetKinematic(bool newValue)
    {
        var bodies = GetComponentsInChildren<Rigidbody>();
        foreach (var body in bodies)
        {
            body.isKinematic = newValue;
        }
    }
}