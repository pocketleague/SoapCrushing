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


    private Touch touch;
    private float speedModifier;

    void Start()
    {
        startPos = transform.position;
        speedModifier = 0.01f;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.tag == "soap")
                {
                    SelectSoap(hit.collider.gameObject.name);
                }
            }
        }

        if (!EventSystem.current.IsPointerOverGameObject(0))
        {
            if (Input.touchCount > 0 && SingletonClass.instance.CURRENT_LEVEL)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    if (SingletonClass.instance.CURRENT_SOAP.GetComponent<SoapData>().soap_particle_count > 0)
                    {
                        animator_hand.SetBool("crushing", true);
                        soapParent.GetComponentInChildren<Animator>().SetBool("crushing", true);
                        Invoke("Delay", 1f);
                    }
                }
                if (touch.phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3(transform.position.x + (touch.deltaPosition.x * speedModifier),
                                        transform.position.y,
                                        transform.position.z + (touch.deltaPosition.y * speedModifier));

                    waitTime += Time.deltaTime;

                    if (waitTime > 1.0f)
                    {
                        waitTime = 0;
                        GetComponent<AudioSource>().clip = clips[Random.Range(0, clips.Length)];
                        GetComponent<AudioSource>().Play();
                    }
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    CancelInvoke("Delay");
                    Debug.Log("gggggggggg cancelled crushing");

                    SingletonClass.instance.IS_CRUSHING = false;
                    animator_hand.SetBool("crushing", false);
                    //   animator_soap.SetBool("crushing", false);
                    soapParent.GetChild(0).GetComponentInChildren<Animator>().SetBool("crushing", false);
                }
            }
        }
        
    }
    void Delay()
    {
        Debug.Log("gggggggggg activated crushing");
        SingletonClass.instance.IS_CRUSHING = true;
    }

    void OnMouseDown()
    {
        //if (!EventSystem.current.IsPointerOverGameObject())
        //{
        //    Debug.Log("ddddd");
        //    screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        //    offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        //    if (SingletonClass.instance.CURRENT_SOAP.GetComponent<SoapData>().soap_particle_count > 0)
        //    {
        //        animator_hand.SetBool("crushing", true);
        //        soapParent.GetComponentInChildren<Animator>().SetBool("crushing", true);
        //        Invoke("Delay", 1f);
        //    }
        //}
    }

    void OnMouseDrag()
    {
        //if (!EventSystem.current.IsPointerOverGameObject())
        //{
        //    Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        //    Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        //    transform.position = new Vector3(cursorPosition.x * 1f, gameObject.transform.position.y, cursorPosition.z);

        //    waitTime += Time.deltaTime;

        //        if (waitTime > 1.0f)
        //    {
        //        waitTime = 0;
        //        GetComponent<AudioSource>().clip = clips[Random.Range(0, clips.Length)];
        //        GetComponent<AudioSource>().Play();
        //    }
        //}
    }

    void OnMouseUp()
    {
        //if (!EventSystem.current.IsPointerOverGameObject())
        //{
        //    CancelInvoke("Delay");
        //    SingletonClass.instance.IS_CRUSHING = false;
        //    animator_hand.SetBool("crushing", false);
        //    //   animator_soap.SetBool("crushing", false);
        //    soapParent.GetChild(0).GetComponentInChildren<Animator>().SetBool("crushing", false);
        //}

    }

    public void SelectSoap(string name)
    {
        if (SingletonClass.instance.CURRENT_SOAP)
        {
            Destroy(SingletonClass.instance.CURRENT_SOAP);
        }
        int id = 0;

        if (name == "Chain")
        {
            id = 0;
        }else if (name == "Cone")
        {
            id = 1;
        }
        else if (name == "Plane")
        {
            id = 2;
        }
        else if (name == "Roll")
        {
            id = 3;
        }

        SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().fillingBar.fillAmount = 1;

        SingletonClass.instance.CURRENT_SOAP = Instantiate(SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().Soaps[id], SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().soapSpawnPos.transform.position, Quaternion.Euler(-90f, 0f, 0f), SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().soapSpawnPos.transform);
        SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().crusher.ChangeMaterial(SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().Soaps[id].GetComponentInChildren<MeshRenderer>().sharedMaterial);
        //  SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().crusher.ChangeMaterial(SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().Soaps[id].GetComponent<SoapData>().mat);

        Destroy(SingletonClass.instance.CURRENT_LEVEL.GetComponent<LevelData>().Soaps[id]);
    }
}
