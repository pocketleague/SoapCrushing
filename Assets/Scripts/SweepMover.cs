using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepMover : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown()
    {
        //if (!EventSystem.current.IsPointerOverGameObject(0))
        //{
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        // }
    }

    void OnMouseDrag()
    {

        //if (!EventSystem.current.IsPointerOverGameObject(0))
        //{
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = new Vector3(cursorPosition.x * 1f, gameObject.transform.position.y, cursorPosition.z);
    //}
    }

    void OnMouseUp()
    {
        transform.GetComponentInChildren<Sweeper>().isSweeping = true;
        transform.GetComponentInChildren<Sweeper>().OnRelease();

    }
}
