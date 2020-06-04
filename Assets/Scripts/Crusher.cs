using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    public GameObject [] prefab;

    void Start()
    {
        InvokeRepeating("Crush", 1, .01f);
    }

    void Update()
    {

    }

    void Crush()
    {
        GameObject obj = Instantiate(prefab[Random.Range(0, 6)]);
        obj.transform.localPosition = Random.insideUnitSphere * 0.2f + transform.position;
        obj.transform.localScale = Vector3.one * Random.Range(0.7f, 1f);
    }
}
