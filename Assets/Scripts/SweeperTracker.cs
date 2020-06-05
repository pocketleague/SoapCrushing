using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweeperTracker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody>().isKinematic = false;
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    other.GetComponent<Rigidbody>().isKinematic = true;
    //}
}
