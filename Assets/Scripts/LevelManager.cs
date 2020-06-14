using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject [] levels;
    public GameObject chain, cones, plain, roll;
    public GameObject gas, flame, pan, table;
    public GameObject cam1, cam2;

    public Vector3 cam1_pos;

    public Material[] mats;


    void Start()
    {
        cam1_pos = cam1.transform.position;
        NextLevel();
    }

    private void Update()
    {
        if (SingletonClass.instance.START_COOKING)
        {
            SingletonClass.instance.START_COOKING = false;
            cam1.SetActive(false);
            cam2.SetActive(true);
            flame.SetActive(true);

            StartCoroutine(CreateMold());

           
        }
    }

    IEnumerator CreateMold()
    {
        yield return new WaitForSeconds(1);

        for (int i = 0; i < mats.Length; i++)
        {
            mats[i].SetFloat("_Glossiness", .01f);
        }

        yield return new WaitForSeconds(1);

        SingletonClass.instance.CURRENT_LEVEL.GetComponent<Animator>().SetBool("flip", true);


    }

    public void NextLevel()
    {
        for (int i = 0; i < mats.Length; i++)
        {
            mats[i].shader = Shader.Find("Standard");
        }

        if (SingletonClass.instance.CURRENT_LEVEL)
            Destroy(SingletonClass.instance.CURRENT_LEVEL);

        SingletonClass.instance.LEVEL++;
        SingletonClass.instance.CURRENT_LEVEL = Instantiate(levels[SingletonClass.instance.LEVEL-1], transform);

    //    SelectSoap(0);
    }

    public void Cook()
    {
        cam1.transform.parent = SingletonClass.instance.CURRENT_LEVEL.transform;

        for (int i = 0; i < SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().Soaps.Length; i++)
        {
            if (SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().Soaps[i])
            {
                Destroy(SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().Soaps[i]);
            }
        }

        SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().hand.SetActive(false);

        SingletonClass.instance.CURRENT_LEVEL.GetComponent<Animator>().SetBool("moveCam", true);
        //gas.SetActive(true);
        //pan.SetActive(true);
        //table.SetActive(false);



    }

    public void SelectSoap(int id)
    {
        if (SingletonClass.instance.CURRENT_SOAP)
        {
            Destroy(SingletonClass.instance.CURRENT_SOAP);
        }

     

        SingletonClass.instance.CURRENT_SOAP = Instantiate(SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().Soaps[id], SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().soapSpawnPos.transform.position, Quaternion.Euler(-90f, 0f, 0f), SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().soapSpawnPos.transform);
        SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().crusher.ChangeMaterial(SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().Soaps[id].GetComponentInChildren<MeshRenderer>().sharedMaterial);
      //  SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().crusher.ChangeMaterial(SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().Soaps[id].GetComponent<SoapData>().mat);


        Destroy(SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().Soaps[id]);
    }
}
