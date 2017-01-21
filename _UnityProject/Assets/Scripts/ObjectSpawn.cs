using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    [Header("Public")]
    public MovableObject objectToSpawn;

    [Header("Private")]
    [SerializeField]
    private Transform spawnTransform;


    private MovableObject myChild;

	// Use this for initialization
	void Start ()
    {
        myChild = Instantiate<MovableObject>(objectToSpawn, spawnTransform, false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!myChild.gameObject.activeSelf)
        {
            myChild.transform.position = spawnTransform.position;
            myChild.transform.rotation = spawnTransform.rotation;
            myChild._Rigid.velocity = Vector3.zero;
            myChild.gameObject.SetActive(true);
        }
	}
}
