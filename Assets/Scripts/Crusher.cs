using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    public GameObject[] prefab;
    public Material mat;


    void Start()
    {
        prefab[0].GetComponentInChildren<MeshRenderer>().material = mat;

        InvokeRepeating("Crush", 1, .01f);
    }

    void Update()
    {

    }

    void Crush()
    {
        if (SingletonClass.instance.IS_CRUSHING)
        {
//            GameObject obj = Instantiate(prefab[Random.Range(0, 6)]);
            GameObject obj = Instantiate(prefab[0]);

            obj.transform.localPosition = Random.insideUnitSphere * 0.2f + transform.position;
            obj.transform.localScale = Vector3.one * Random.Range(0.7f, 1f);
        }
    }

    public void ChangeMaterial()
    {

    }
}
