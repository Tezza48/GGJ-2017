using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerableObject : MonoBehaviour {

    public bool triggered;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public virtual void TriggerObject()
    {
        if (!triggered)
        {
            triggered = true;
        }

    }
}
