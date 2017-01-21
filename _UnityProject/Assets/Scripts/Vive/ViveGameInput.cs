using System;
using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using UnityEngine;

public class ViveGameInput : MonoBehaviour
{
    ulong dpadAny =(ulong)(EVRButtonId.k_EButton_DPad_Up | EVRButtonId.k_EButton_DPad_Down | EVRButtonId.k_EButton_DPad_Left | EVRButtonId.k_EButton_DPad_Right);

    SteamVR_Controller.Device Controller { get { return SteamVR_Controller.Input((int)trackedObject.index); } }
    SteamVR_TrackedObject trackedObject;

    // Use this for initialization
    void Start()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Controller == null)
        {
            Debug.Log("This Controller not Initialized!");
            return;
        }

        if (Controller.GetTouch(EVRButtonId.k_EButton_SteamVR_Touchpad))
        {
            DrawTPLine();
        }
        if (Controller.GetPressDown(EVRButtonId.k_EButton_SteamVR_Touchpad))
        {
            DoTeleport();
        }

    }

    private void DrawTPLine()
    {
        Vector3 pos = transform.position;
        Vector3 dir = transform.forward;
        Debug.DrawRay(pos, dir);
    }

    private void DoTeleport()
    {
        Debug.Log("You Pressed the d-pad.");
    }
}
