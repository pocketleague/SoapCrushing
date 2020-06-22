using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Crusher : MonoBehaviour
{
    public GameObject[] prefab;
    public GameObject particle_crush;

    public Material mat_red, mat_blue;

    public float crushRate;
    
    void Start()
    {
        InvokeRepeating("Crush", 1, crushRate);
    //    InvokeRepeating("CrushParticles", 1, .1f);
    }

    void Crush()
    {
        if (SingletonClass.instance.IS_CRUSHING)
        {
            //   GameObject obj = Instantiate(prefab[Random.Range(0, prefab.Length)]);
            if (SingletonClass.instance.CURRENT_SOAP != null)
            {
                if (SingletonClass.instance.CURRENT_SOAP.GetComponent<SoapData>().soap_particle_count > 0)
                {
                    float z = ((float)SingletonClass.instance.CURRENT_SOAP.GetComponent<SoapData>().soap_particle_count) / (float)SingletonClass.instance.CURRENT_SOAP.GetComponent<SoapData>().soap_particle_total;

                    SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().fillingBar.fillAmount = z;
                    SingletonClass.instance.CURRENT_SOAP.transform.localScale = new Vector3(SingletonClass.instance.CURRENT_SOAP.transform.localScale.x, SingletonClass.instance.CURRENT_SOAP.transform.localScale.y, z);

                    GameObject obj = Instantiate(prefab[0]);

                    obj.transform.localPosition = Random.insideUnitSphere * 0.2f + transform.position;
                    obj.transform.parent = SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().stencil.transform.GetChild(0);

                    SingletonClass.instance.CURRENT_SOAP.GetComponent<SoapData>().soap_particle_count--;

                }
                else
                {
                    Debug.Log("Soap is over");
                }

            }


            //  obj.transform.localScale = Vector3.one * Random.Range(0.7f, 1f);
        }
    }

    void CrushParticles()
    {
        if (SingletonClass.instance.IS_CRUSHING)
        {
            Instantiate(particle_crush, transform.position, Quaternion.identity);
        }
    }
    public void ChangeMaterialRed()
    {
        for (int i = 0; i < prefab.Length; i++)
        {
            prefab[i].GetComponentInChildren<MeshRenderer>().sharedMaterial = mat_red;
        }
    }

    public void ChangeMaterialBlue()
    {
        for (int i = 0; i < prefab.Length; i++)
        {
            prefab[i].GetComponentInChildren<MeshRenderer>().sharedMaterial = mat_blue;
        }
    }

    public void ChangeMaterial(Material mat)
    {
        for (int i = 0; i < prefab.Length; i++)
        {
            prefab[i].GetComponentInChildren<MeshRenderer>().sharedMaterial = mat;
        }
    }
}
