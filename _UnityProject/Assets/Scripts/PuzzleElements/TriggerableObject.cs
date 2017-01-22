using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerableObject : MonoBehaviour {

    [SerializeField]
    protected bool triggered;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void TriggerObject()
    {
        if (!triggered)
        {
            triggered = true;
        }

    }
}
