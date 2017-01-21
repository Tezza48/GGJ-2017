using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovableObject : MonoBehaviour
{

    Rigidbody _rigid;

    public Rigidbody _Rigid
    {
        get
        {
            return _rigid;
        }

        set
        {
            _rigid = value;
        }
    }

    void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {
        gameObject.tag = "movable";
        gameObject.layer = LayerMask.GetMask("movable");

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_rigid.IsSleeping());
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "deadZone")
        {
            gameObject.SetActive(false);
        }
    }
}
