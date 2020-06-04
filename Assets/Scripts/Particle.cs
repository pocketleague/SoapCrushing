using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    void Start()
    {
        Invoke("MakeKinemetic", 2);
    }

    void MakeKinemetic()
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }
}
