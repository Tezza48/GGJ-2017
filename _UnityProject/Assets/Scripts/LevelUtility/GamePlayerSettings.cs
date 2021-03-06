﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayerSettings : MonoBehaviour {

    private int allowedLandmasses = ~0;

    public int AllowedLandmasses { get { return allowedLandmasses; } }

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(allowedLandmasses);
	}

    public void AllowLandmass(int landmassTag)
    {
        allowedLandmasses |= landmassTag;
    }

    public void DissalowLandmass(int landmassTag)
    {
        allowedLandmasses &= ~landmassTag;
    }

    public bool canTeleportTo(int landmassTag)
    {
        return (allowedLandmasses & landmassTag) != 0;
    }
}
