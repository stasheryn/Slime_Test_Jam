using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitboxParent : MonoBehaviour
{
    public virtual void OnCollisionEnter(Collision other)
    {
        Debug.Log("VAR");
    }
}
