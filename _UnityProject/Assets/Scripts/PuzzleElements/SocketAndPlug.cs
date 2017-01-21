using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketAndPlug : MonoBehaviour {

    public enum SocketAndPlugActions
    {
        None = 0,
        Unplug = 1,
        PlugIn = 2
    }


    [Header("Public")]
    public TriggerableObject triggerOnDisconnect;// Trigger to fire when unplugged
    public TriggerableObject triggerOnConnect;// trigger to fire when plugged in

    public SocketAndPlugActions puzzleActions;

    [Header("Private")]
    [SerializeField]
    private Plug plug;// The plug, child object

	// Use this for initialization
	void Start ()
    {
        plug.parent = this;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void PluggedIn()
    {
        if ((puzzleActions & SocketAndPlugActions.PlugIn) != 0)
        {
            triggerOnConnect.TriggerObject();
        }
    }

    public void Unplug()
    {
        if ((puzzleActions & SocketAndPlugActions.Unplug) != 0)
        {
            triggerOnDisconnect.TriggerObject();
        }
    }
}
