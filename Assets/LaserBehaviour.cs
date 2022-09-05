using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    //smit's work
    Rigidbody laserRigidbody;

    private void Awake()
    {
        laserRigidbody = GetComponent<Rigidbody>();
    }

  

    private void Update()
    {
        laserRigidbody.velocity = Vector3.forward * 3;
    }

    private void OnCollisionEnter(Collision collision)
    {
        laserRigidbody.velocity = Vector3.zero;
    }

}
