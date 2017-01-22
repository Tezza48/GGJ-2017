using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBallSpawner : ObjectSpawn
{
    public int puzzleID;
	// Use this for initialization
	void Start()
    {
        myChild = Instantiate((PuzzleBall)objectToSpawn, spawnTransform, false);
        ((PuzzleBall)myChild).PuzzleID = puzzleID;
	}
	
	// Update is called once per frame
	new void Update ()
    {
        base.Update();
	}

}
