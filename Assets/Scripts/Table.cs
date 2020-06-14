using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "particle")
        {
            Debug.Log("ggggglllll");
            Destroy(collision.gameObject);
        }
    }
}
