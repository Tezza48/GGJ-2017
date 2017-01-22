using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBall : MovableObject
{
    private int puzzleID;

    public int PuzzleID { get { return puzzleID; } set { puzzleID = value; } }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "deadZone")
        {
            print("asdasdasdasdasd");
            gameObject.SetActive(false);
        }
    }
}
