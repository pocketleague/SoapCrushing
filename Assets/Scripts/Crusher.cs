using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Crusher : MonoBehaviour
{
    public GameObject[] prefab;
    public Material mat_red, mat_blue;

    public float crushRate;

    void Start()
    {
        InvokeRepeating("Crush", 1, crushRate);
    }

    void Crush()
    {
        if (SingletonClass.instance.IS_CRUSHING)
        {
    //        GameObject obj = Instantiate(prefab[Random.Range(0, 6)]);
            GameObject obj = Instantiate(prefab[0]);

            obj.transform.localPosition = Random.insideUnitSphere * 0.2f + transform.position;
          //  obj.transform.localScale = Vector3.one * Random.Range(0.7f, 1f);
        }
    }

    public void ChangeMaterialRed()
    {
        for (int i = 0; i < prefab.Length; i++)
        {
            prefab[i].GetComponentInChildren<MeshRenderer>().material = mat_red;
        }
    }

    public void ChangeMaterialBlue()
    {
        for (int i = 0; i < prefab.Length; i++)
        {
            prefab[i].GetComponentInChildren<MeshRenderer>().material = mat_blue;
        }
    }
}
