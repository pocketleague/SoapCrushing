using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweeper : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent.parent = transform;
    }
}
