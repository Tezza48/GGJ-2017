using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCube : MonoBehaviour {


    Vector3 cubeInitialPos;


    void Start()
    {
        cubeInitialPos = transform.position;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "deadZone")
        {
            transform.position = cubeInitialPos;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
