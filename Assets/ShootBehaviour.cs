using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootBehaviour : MonoBehaviour
{
    //smit's work

    [SerializeField]
    Transform shootPosition;

    [SerializeField]
    GameObject laserPrefab;

    private float fireRate;

    private void Start()
    {
        fireRate = 0.25f;
    }


    private void Awake()
    {
        //subscribing: if using c# events behaviour in PlayerInput
        GetComponent<PlayerInput>().onActionTriggered += HandleShootWithCSharpevents;
    }

    //---------- for sendMessage method
    //public void OnShoot(InputValue input)
    //{

    //    if(input.isPressed)
    //    {
    //        InvokeRepeating(nameof(FireLaser), 0f, fireRate);
    //    }
    //    else
    //    {
    //        CancelInvoke(nameof(FireLaser));
    //    }    
    //}
    //--------------------

    //----------- a common method for Instantiating bullets----
    private void FireLaser()
    {
        Instantiate(laserPrefab, shootPosition.position, Quaternion.identity);
    }
    //----------------------


    //------------------ for Invoke C# events
    private void HandleShootWithCSharpevents(InputAction.CallbackContext context)
    {
        if (context.action.name == "Shoot")
        {
            if (context.action.triggered)
            {
                InvokeRepeating(nameof(FireLaser), 0f, fireRate);
            }
            else
            {
                CancelInvoke(nameof(FireLaser));
            }
        }
    }
    //----------------------
}
