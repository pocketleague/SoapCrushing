using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject sweeper, hand;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ActivateSweeper()
    {
        hand.SetActive(false);
        sweeper.SetActive(true);
    }
}
