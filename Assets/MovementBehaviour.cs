using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//using UnityEngine.Events;

public class MovementBehaviour : MonoBehaviour
{
    //smit's work

    Rigidbody playerRigidBody;

    Vector2 inputVector;

    float playerSpeed;

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();

        playerSpeed = 10;
    }

    private void FixedUpdate()
    {
        Vector3 movementVector = new Vector3(inputVector.x, 0, inputVector.y) * playerSpeed;

        playerRigidBody.velocity = movementVector;
    }


    //select this when the Behaviour is selected as: Invoke Unity events
    public void DebugTest()
    {
        Debug.Log("Success");
    }


    //if using send message as a behaviour in PlayerInput:
    //public void OnMovement(InputValue input)
    //{
    //    inputVector = input.Get<Vector2>();

    //    //inputVector =  new Vector3(movementVector.x, 0, movementVector.y) * 10;

    //    //Debug.Log("on movement action called: "+ movementVector);
    //}

    private void Awake()
    {
        GetComponent<PlayerInput>().onActionTriggered += HandleAction;
    }

    private void HandleAction(InputAction.CallbackContext context)
    {
        if(context.action.name == "Movement")
        {
            inputVector = context.ReadValue<Vector2>();
            Debug.Log("movement C# event");
        }
    }
    
}
