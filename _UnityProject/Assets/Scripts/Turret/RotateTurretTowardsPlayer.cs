using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTurretTowardsPlayer : MonoBehaviour {


    GameObject player;

    //shooting
    float currentTime;
    int index;
    [SerializeField] GameObject[] _bullets;
    [SerializeField] float cd;
    


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        LookAtPlayer();
        Shoot();
    }

    void LookAtPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;

        Quaternion target = Quaternion.FromToRotation(Vector3.right, direction);

        transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime);
    }

    void Shoot()
    {
        currentTime += Time.deltaTime;



        if (currentTime >= cd)
        {
            _bullets[index].transform.position = transform.position;
            _bullets[index].transform.rotation = transform.rotation * Quaternion.Euler(0,90,0);
            if (_bullets[index].transform.parent != null)
                _bullets[index].transform.parent = null;
            _bullets[index].gameObject.SetActive(true);

            Debug.Log(index);

            if (index >= _bullets.Length-1)
                index = 0;
            else if (index < _bullets.Length-1)
                index++;
            currentTime = 0;
        }
    }







}
