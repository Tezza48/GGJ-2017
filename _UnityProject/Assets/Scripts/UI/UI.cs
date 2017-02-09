using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

void OnCollisionEnter2D (Collision2D coll) {
        if (coll.gameObject.tag == "Start")
            Debug.Log("start");
    }
}
