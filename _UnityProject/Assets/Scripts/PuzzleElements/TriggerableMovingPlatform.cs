using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerableMovingPlatform : TriggerableObject
{

    enum Direction
    {
        forward,
        backward
    }

    public int landmassStart, landmassMe, landmassEnd;

    private float speed = 2.0f;
    private float closeEnough = 0.1f;

    [SerializeField]
    private Transform start, end;
    private Direction direction;

    private GamePlayerSettings playerSettings;

    // Use this for initialization
    void Start()
    {
        start.parent = null;
        end.parent = null;

        playerSettings = FindObjectOfType<GamePlayerSettings>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            Move();
        }

        if (playerSettings.transform.parent == transform)
        {
            playerSettings.AllowLandmass(landmassMe);
        }
    }

    private void Move()
    {
        if (direction == Direction.forward)
        {
            if ((transform.position - end.position).magnitude > closeEnough)
            {
                transform.position += (end.position - start.position).normalized * speed * Time.deltaTime;
            }
            else
            {
                direction = Direction.backward;
            }
        }
        else if (direction == Direction.backward)
        {
            if ((transform.position - start.position).magnitude > closeEnough)
            {
                transform.position += (start.position - end.position).normalized * speed * Time.deltaTime;
            }
            else
            {
                direction = Direction.forward;
            }
        }
    }

    public override void TriggerObject()
    {
        if (!triggered)
        {
            triggered = true;
        }

    }

    public void OnTriggerEnter(Collider other)
    {

        /*
         if player is on platform
         */

         if (playerSettings.transform.parent.parent == transform)
        {
            if (other.transform == start.transform)
            {
                playerSettings.AllowLandmass(landmassStart);
            }
            else if (playerSettings.transform == end.transform)
            {
                playerSettings.AllowLandmass(landmassEnd);
            }
        }
        /*
        if player is not on platform
        */
        else
        {
            //which side is the player
            //is the player on the start side
            if (((playerSettings.AllowedLandmasses & landmassStart) != 0) && other.transform == start.transform)
            {
                playerSettings.AllowLandmass(landmassMe);
            }
            else if (((playerSettings.AllowedLandmasses & landmassEnd) != 0) && other.transform == end.transform)
            {
                playerSettings.AllowLandmass(landmassMe);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (playerSettings.transform.parent.parent == transform)
        {
            playerSettings.DissalowLandmass(~0);
            playerSettings.AllowLandmass(landmassMe);
        }
        /*
        if player is not on platform
        */
        else
        {
            playerSettings.DissalowLandmass(landmassMe);
        }
    }
}
