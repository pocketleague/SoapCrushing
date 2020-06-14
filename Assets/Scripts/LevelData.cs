using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public GameObject soapSpawnPos;
    public Crusher crusher;
    public GameObject[]Soaps;
    public GameObject hand;
    public GameObject stencil;
    public GameObject confetti;

    public void ActivateCam2()
    {
        SingletonClass.instance.START_COOKING = true;
    }

    public void ActivateConfetti()
    {
        SingletonClass.instance.START_CONFETTI = true;
    }
}
