using System.Collections;
using UnityEngine;

public class SelectObject : MonoBehaviour {


    GameObject[] movableObject;
    bool isFree = false;
    float currentTime = 0f;
    float endTime = 1f;

    private void OnMouseOver()
    {
         gameObject.tag = "active";
    }
    private void OnMouseExit()
    {
        gameObject.tag = "Untagged";
    }

    



}
