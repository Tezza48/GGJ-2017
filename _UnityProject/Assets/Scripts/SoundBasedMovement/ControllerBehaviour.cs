using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBehaviour : MonoBehaviour {

    [SerializeField] CaptureSound _captureSound;
    GameObject objectThatWillGetMoved;
    bool isUsable;
    bool isControlled;


    //hold control
    float currentTime = 0f;
    float endTime = 1f;

    //Physic
    float dist = 1000f;
    RaycastHit _raycast;
    Ray _ray;
    int layerMask;

    [Header("Force")]
    [SerializeField]
    float force;

    [Header("Normal Force")]
    [SerializeField] float normalForceMultiplier;

    [Header("Catapulte Force")]
    [SerializeField] float catapulteThreshold;
    [SerializeField] float catapulteForceMultiplier;

    void Awake()
    {
        layerMask = LayerMask.GetMask("movable");
    }

    //void OnMouseEnter()
    //{
    //    if (gameObject.tag == "movable")
    //    {
    //        objectThatWillGetMoved = GameObject.FindGameObjectWithTag("movable");
    //        print("asdasdas");
    //    }
    //}

    void Update()
    {
        force = _captureSound.Force;

        Raycast();
        LosingContact();
        AddVerticalForce();
    }


    void Raycast()
    {
        _ray.origin = transform.position;
        _ray.direction = transform.forward;
        if (Physics.Raycast(_ray, out _raycast, dist, layerMask))
        {
            if (_raycast.transform.tag == "movable" && !isUsable)
            {
                objectThatWillGetMoved = _raycast.transform.gameObject;
                dist = Vector3.Distance(objectThatWillGetMoved.transform.position, transform.position);
                Debug.Log(dist);
                isUsable = true;
                isControlled = true;
                currentTime = 0f;
                Debug.Log("Got the object");
            }
            else
            {
                isControlled = false;
                dist = 1000f;
            }
        }
        else
        {
            isControlled = false;
            dist = 1000f;
        }
    }

    void LosingContact()
    {
        if (!isControlled && isUsable)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= endTime)
            {
                isUsable = false;
                currentTime = 0f;
                objectThatWillGetMoved = null;
            }
        }
    }

    void AddVerticalForce()
    {
        if (isUsable)
        {
            if (force > 8.5f && force <= catapulteThreshold)
            {
                Levitate();
            }
            else if (force > catapulteThreshold)
            {
                Catapulte();
            }
        }
    }

    void Levitate()
    {
        objectThatWillGetMoved.GetComponent<Rigidbody>().AddForce(force * Time.deltaTime * Vector3.up * normalForceMultiplier);
    }

    void Catapulte()
    {
        objectThatWillGetMoved.GetComponent<Rigidbody>().AddForce(force * Time.deltaTime * new Vector3(0f, 1f, 0f) + (objectThatWillGetMoved.transform.position - transform.position).normalized * catapulteForceMultiplier);
        print("cata");
    }

    void SideMove()
    {

    }

}
