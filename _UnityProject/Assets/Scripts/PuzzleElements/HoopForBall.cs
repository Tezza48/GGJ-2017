using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopForBall : MonoBehaviour
{

    [SerializeField]
    private TriggerableMovingPlatform platform;

    [SerializeField]
    private int puzzleID;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        {
            PuzzleBall ball = other.GetComponent<PuzzleBall>();
            if (ball != null)
            {
                if (ball.PuzzleID == puzzleID)
                {
                    platform.TriggerObject();
                }
            }
        }
    }
}
