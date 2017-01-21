using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBehaviour : MonoBehaviour {

	[SerializeField] CaptureSound _captureSound;

    [SerializeField] float threshold;




    Rigidbody objectThatWillGetMoved;



    //Physic
    float dist=1000f;
    RaycastHit _raycast;
    Ray _ray;
    int layerMask;

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
        Raycast();
    }


    void Raycast()
    {
        _ray.origin = transform.position;
        _ray.direction = transform.forward;
        if (Physics.Raycast(_ray, out _raycast, dist, layerMask))
        {
            if (_raycast.collider.tag == "movable")
            {
                _raycast.collider.tag = "active";
            }
        }
        else
        {
            _raycast.collider.tag = "movable";
        }
    }



}
