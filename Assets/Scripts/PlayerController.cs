using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float rotationAmount = 1f;
    [SerializeField] float speed = 15f;
    [SerializeField] float boostSpeed = 30f;

    Rigidbody2D playerRigidBody;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
       playerRigidBody = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
        
    }

    public void DisableControls()
    {;
        canMove = false;
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        } else
        {
            surfaceEffector2D.speed = speed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRigidBody.AddTorque(rotationAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRigidBody.AddTorque(-rotationAmount);
        }
    }
}
