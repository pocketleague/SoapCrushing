using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweeper : MonoBehaviour
{
    public bool isSweeping;
    List<Transform> list_child;

    private void OnTriggerEnter(Collider other)
    {
        if (!isSweeping)
        {
            Debug.Log("wwwwwwwwwwwww");
            other.transform.parent.parent = transform;
        }
    }

    public void OnRelease()
    {
        //for (int i = 0; i < transform.childCount; i++)
        //{
        //    transform.GetChild(0).GetComponentInChildren<Rigidbody>().isKinematic = false;
        //    transform.GetChild(0).transform.parent = null;
        //    Debug.Log("llllllllllllll");
        //}

        list_child = new List<Transform>();

        foreach (Transform child in transform)
        {
            list_child.Add(child);
        }

        foreach (Transform tr in list_child)
        {
            tr.GetComponentInChildren<Rigidbody>().isKinematic = false;
            tr.GetChild(0).transform.parent = null;
        }

        Invoke("Release", 2f);
    }

    void Release()
    {
        list_child.Clear();
        isSweeping = false;
    }
}


