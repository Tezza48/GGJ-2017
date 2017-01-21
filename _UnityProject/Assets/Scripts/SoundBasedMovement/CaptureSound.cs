using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureSound : MonoBehaviour {

    [SerializeField]float intesity;
    [SerializeField]float threshold = 0.85f;
    [SerializeField] FFTWindow _fftWindows;
    GameObject player;

    //ActiveObject
    [Header("Active Object")]
    [SerializeField]float normalForceMultiplier;
    Rigidbody activeObj;

    //catapulte mode
    [Header("Catapulte Volume Level")]
    [SerializeField]float catapulteForceMultiplier;
    [SerializeField]float catapultVolumeLevel;
    bool isCatapulteMode;

    //AudioShitNooneUnderstands
	AudioSource _audio;
    float secondsHold;
    string microphonesName;
    float force = 0f;
    public float Force
    {
        get{return force; }
        set { force = value;}
    }
    float[] spectrum = new float[256];


    void Awake()
    {
        _audio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

	void Start()
	{
        _audio.Stop();
        _audio.clip = Microphone.Start(microphonesName, true, 10, 44100);
        _audio.loop = true;

        foreach (string device in Microphone.devices)
            if (microphonesName == null)
                microphonesName = device;

        if (Microphone.IsRecording(microphonesName))
        {
            while (!(Microphone.GetPosition(microphonesName) > 0)) { }
            _audio.Play();
        }
        else
        {
            print(microphonesName + "doesn't work");
        }        
    }


    void Update()
    {
        FromSoundToForce();
    }


    void FromSoundToForce()
    {
        _audio.GetSpectrumData(spectrum, 0, _fftWindows);
        for (int i = 0; i < spectrum.Length; i++)
        {
            if (spectrum[i] > threshold)
            {
                //we get all intensities in spectrum
                intesity = spectrum[i] * 100f;

                //save the highest value
                if (Force < intesity)
                    Force = intesity;
            }
            else
            {
                //when intensity is past threshold we reset the max volumes
                Force = 0;
            }


        }

    }






    //void Levitate(Rigidbody activeObject, float _force)
    //{
    //    if (activeObj != null)
    //        activeObject.AddForce(_force * Time.deltaTime * Vector3.up * normalForceMultiplier);
    //}


    //void CatapulteMode(Rigidbody activeObject, float _force)
    //{
    //    if (activeObj != null)
    //    {
    //        activeObject.AddForce(_force * Time.deltaTime * new Vector3(0f, 1f, 0f) + (activeObj.transform.position - player.transform.position).normalized * catapulteForceMultiplier);
    //    }
    //}
}
