using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeMeasurement : MonoBehaviour {


    float force;
    ParticleSystem _particle;
    CaptureSound _capture;



    private void Awake()
    {
        _capture = GameObject.Find("GamePlayerSettings").GetComponent<CaptureSound>();
        _particle = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        force = _capture.Force;
        Debug.Log(force);
        var ma = _particle.main;
        ma.startSize = force/10;
    }





}
