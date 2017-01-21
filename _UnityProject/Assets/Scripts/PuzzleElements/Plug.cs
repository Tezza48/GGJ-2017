using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plug : MonoBehaviour
{

    public SocketAndPlug parent;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "socket")
        {
            parent.PluggedIn();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "socket")
        {
            parent.Unplug();
        }
    }
}
