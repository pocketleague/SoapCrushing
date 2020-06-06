using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject [] levels;

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

    }
}
