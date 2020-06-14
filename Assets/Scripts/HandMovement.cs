using UnityEngine;
using UnityEngine.EventSystems;

public class HandMovement : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    public Vector3 startPos;

    public Animator animator_hand, animator_soap;
    public Transform soapParent;

    private float waitTime;

    public AudioClip [] clips;

    void Start()
    {
        startPos = transform.position;

    }

    void Update()
    {

    }

    void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject(0))
        {
            Debug.Log("ddddd");
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

            if (SingletonClass.instance.CURRENT_SOAP.GetComponent<SoapData>().soap_particle_count > 0)
            {
                animator_hand.SetBool("crushing", true);
                soapParent.GetComponentInChildren<Animator>().SetBool("crushing", true);
                Invoke("Delay", 1f);
            }
        }
    }

    void Delay()
    {
       
         SingletonClass.instance.IS_CRUSHING = true;

    }

    void OnMouseDrag()
    {

        if (!EventSystem.current.IsPointerOverGameObject(0))
        {
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
            transform.position = new Vector3(cursorPosition.x * 1f, gameObject.transform.position.y, cursorPosition.z);

            waitTime += Time.deltaTime;

            if (waitTime > 0.2f)
            {
                waitTime = 0;
                GetComponent<AudioSource>().clip = clips[Random.Range(0, clips.Length)];
                GetComponent<AudioSource>().Play();
            }
        }
    }



    void OnMouseUp()
    {
        if (!EventSystem.current.IsPointerOverGameObject(0))
        {
            CancelInvoke("Delay");
            SingletonClass.instance.IS_CRUSHING = false;
            animator_hand.SetBool("crushing", false);
            //   animator_soap.SetBool("crushing", false);
            soapParent.GetChild(0).GetComponentInChildren<Animator>().SetBool("crushing", false);
        }

    }
}
