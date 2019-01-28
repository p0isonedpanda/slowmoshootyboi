using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float t;

    void Start()
    {
        Destroy(gameObject, t);
    }
}
