using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureSound : MonoBehaviour {


	AudioSource _audio;
    float secondsHold;
    string microphonesName;


    void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

	void Start()
	{
        foreach (string device in Microphone.devices)
        {
            if (microphonesName == null)
                microphonesName = device;
        }
        //print();

        _audio.mute = true;
        _audio.loop = true;
    }


    void Update()
    {



        if (Input.GetKey(KeyCode.Mouse0) && !(Microphone.GetPosition("device1") > 0))
        {
            secondsHold += Time.deltaTime;
            print(secondsHold);
            _audio.clip = Microphone.Start("device1", true, 10, 44100);
        }
        else
        {
            secondsHold = 0f;
            Microphone.End("device1");
        }
        
    }
}
