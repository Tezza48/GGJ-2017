using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

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
    [SerializeField]   float force;

    [Header("Normal Force")]
    [SerializeField] float normalForceMultiplier;

    [Header("Catapulte Force")]
    [SerializeField] float catapulteThreshold;
    [SerializeField] float catapulteForceMultiplier;

    void Awake()
    {
        layerMask = LayerMask.GetMask("movable");
    }

    void Update()
    {
        force = _captureSound.Force;
        //Debug.Log(force);
        Raycast();
        LosingContact();
        AddVerticalForce();
        SideMove();
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
                isUsable = true;
                isControlled = true;
                currentTime = 0f;
               // SideMove();
            }
            else
            {
                isControlled = false;
            }
        }
        else
        {
            isControlled = false;
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
                dist = 1000f;

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
                isUsable = false;
            }
        }
    }

    void Levitate()
    {
        objectThatWillGetMoved.GetComponent<Rigidbody>().AddForce(force * Time.deltaTime * Vector3.up * normalForceMultiplier);
    }

    void Catapulte()
    {
        objectThatWillGetMoved.GetComponent<Rigidbody>().AddForce(force * Time.deltaTime * new Vector3(0f, 1f, 0f) + (objectThatWillGetMoved.transform.position - transform.position).normalized * catapulteForceMultiplier, ForceMode.Impulse);
    }

    void SideMove()
    {
        if (isUsable)
        {
            Vector3 point = _ray.origin + (_ray.direction * dist);

            //Debug.Log(dist);


            // objectThatWillGetMoved.transform.position = new Vector3(point.x, objectThatWillGetMoved.transform.position.y, objectThatWillGetMoved.transform.position.z);
            Vector3 target = new Vector3(point.x, objectThatWillGetMoved.transform.position.y, point.z);
           // objectThatWillGetMoved.transform.position = point;
             objectThatWillGetMoved.transform.position = Vector3.Lerp(objectThatWillGetMoved.transform.position, target, Time.deltaTime * normalForceMultiplier); 
        }
    }

}
