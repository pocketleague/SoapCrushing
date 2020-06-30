using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject [] levels;
    public GameObject chain, cones, plain, roll;
    public GameObject gas, flame, pan, table, steam;
    public GameObject cam1, cam2, cam3;

    public Vector3 cam1_pos;

    public Material[] mats;
    public GameObject btn_cook, btn_next;


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

            SingletonClass.instance.CURRENT_LEVEL.GetComponent<AudioSource>().enabled = true;

            StartCoroutine(CreateMold());
        }

        if (SingletonClass.instance.START_CONFETTI)
        {
            SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().steam.SetActive(false);

            SingletonClass.instance.START_CONFETTI = false;
            ShowConfetti();


            cam2.SetActive(false);
            cam3.SetActive(true);
        }
    }

    IEnumerator CreateMold()
    {
        yield return new WaitForSeconds(1);


        SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().steam.SetActive(false);

        for (int i = 0; i < mats.Length; i++)
        {
            mats[i].SetFloat("_Glossiness", .01f);
        }

        yield return new WaitForSeconds(1);

        SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().bubbles.SetActive(true);

        SingletonClass.instance.CURRENT_LEVEL.GetComponent<Animator>().SetBool("flip", true);

        SingletonClass.instance.CURRENT_LEVEL.GetComponent<AudioSource>().enabled = false;

        yield return new WaitForSeconds(4);

        SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().bubbles.SetActive(false);

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
        SingletonClass.instance.CURRENT_LEVEL = Instantiate(levels[(SingletonClass.instance.LEVEL-1) % 4], transform);

        cam1.SetActive(true);
        cam2.SetActive(false);
        cam3.SetActive(false);

        cam1.GetComponent<CinemachineVirtualCamera>().enabled = true;
        cam1.transform.parent = null;
        cam1.transform.position = cam1_pos;

        btn_cook.SetActive(true);
        btn_next.SetActive(false);

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
        SingletonClass.instance.IS_CRUSHING = false;
        Debug.Log("gggggggggg activated deactivated");

        SingletonClass.instance.CURRENT_LEVEL.GetComponent<Animator>().SetBool("moveCam", true);
        
        btn_cook.SetActive(false);
    }

    void ShowConfetti()
    {

        SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().confetti.SetActive(true);
        btn_cook.SetActive(false);
        btn_next.SetActive(true);


    }

    public void SelectSoap(int id)
    {
        if (SingletonClass.instance.CURRENT_SOAP)
        {
            Destroy(SingletonClass.instance.CURRENT_SOAP);
        }

        //if ()
        //{

        //}
        SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().fillingBar.fillAmount = 1;

        SingletonClass.instance.CURRENT_SOAP = Instantiate(SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().Soaps[id], SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().soapSpawnPos.transform.position, Quaternion.Euler(-90f, 0f, 0f), SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().soapSpawnPos.transform);
        SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().crusher.ChangeMaterial(SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().Soaps[id].GetComponentInChildren<MeshRenderer>().sharedMaterial);
      //  SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().crusher.ChangeMaterial(SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().Soaps[id].GetComponent<SoapData>().mat);

        Destroy(SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().Soaps[id]);
    }
}
