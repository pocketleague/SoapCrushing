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
        if (Input.GetMouseButton(0))
        {
            Debug.Log("yyyyyy");
            //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //RaycastHit hit = Physics.Raycast(mousePos, Vector3.up, 100);
            //if (hit.collider != null)
            //{
            //    Debug.Log(hit.collider.gameObject.name);
            ////    hit.collider.attachedRigidbody.AddForce(Vector2.up);
            //}

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log("uuuuuu");

                // whatever tag you are looking for on your game object
                if (hit.collider.tag == "hand")
                {
                    Debug.Log("iiiiiii");

                    Debug.Log("---> Hit: ");
                }
            }
        }
    }

    public void ActivateSweeper()
    {
        hand.SetActive(false);
        sweeper.SetActive(true);
    }
}
