using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject [] levels;
    public GameObject chain, cones, plain, roll;

    void Start()
    {
        NextLevel();
    }

    public void NextLevel()
    {
        if (SingletonClass.instance.CURRENT_LEVEL)
            Destroy(SingletonClass.instance.CURRENT_LEVEL);

        SingletonClass.instance.LEVEL++;
        SingletonClass.instance.CURRENT_LEVEL = Instantiate(levels[SingletonClass.instance.LEVEL-1], transform);
        SelectSoap(cones);
    }

    public void SelectSoap(GameObject obj)
    {
        Debug.Log("gggg ");
        if (SingletonClass.instance.CURRENT_SOAP)
        {
            Destroy(SingletonClass.instance.CURRENT_SOAP);
        }

        SingletonClass.instance.CURRENT_SOAP = Instantiate(obj, SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().soapSpawnPos.transform.position, Quaternion.Euler(-90f, 0f, 0f), SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().soapSpawnPos.transform);
        SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().crusher.ChangeMaterial(obj.GetComponent<SoapData>().mat);
    }
}
