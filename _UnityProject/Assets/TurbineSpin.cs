using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurbineSpin : MonoBehaviour {

    float speed = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(transform.up, Time.deltaTime * speed);
	}
}
