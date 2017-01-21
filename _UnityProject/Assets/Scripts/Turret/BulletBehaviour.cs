using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

    [SerializeField]float ms;

    void Update()
    {
        transform.position += Time.deltaTime * ms * transform.forward;
    }
}
