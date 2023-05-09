using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveController : MonoBehaviour
{
    private Rigidbody2D body;
    DashController _dashController;

    //Direction handlers
    [SerializeField] private float baseSpeed = 0;
    private float varSpeed;
    private Vector2 _input;

    //Sprinting handler
    [SerializeField] float sprintSpe = 0;
    private bool sprinting;

    Animator idle;
    Animator dash;
    Animator shoot;
    Animator runAndShoot;
    // Start is called before the first frame update
    void Start()
    {
        _dashController = GetComponent<DashController>();
        body = GetComponent<Rigidbody2D>();
        varSpeed = baseSpeed;
        sprinting = false;

        idle = GetComponent<Animator>();
        //dash = GetComponent<Animator>();
        shoot = GetComponent<Animator>();
        runAndShoot = GetComponent<Animator>();
    }

    // Update is called once per frame
    bool spacePressed = false;

    void Update()
    {
        //Get Sprint input
        if (Input.GetKey(KeyCode.LeftShift) && !_dashController.IsDashing()) { sprinting = true; }
        else { sprinting = false; }

        //Handle movement mode
        if (sprinting) { varSpeed = sprintSpe; }
        else if (_dashController.IsDashing())
        {
            sprinting = false;
            varSpeed = _dashController.DashPower();
        }
        else { varSpeed = baseSpeed; }
        move();
    }

    private void OnMove(InputValue value)
    {
        _input = value.Get<Vector2>();
    }

    private void move()
    {
        var velocity = _input * varSpeed * Time.deltaTime;
        transform.Translate(velocity);


        if (Input.GetKey(KeyCode.W))
        {
            idle.SetFloat("moving", idle.GetFloat("moving") + Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            idle.SetFloat("moving", idle.GetFloat("moving") + Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.A))
        {
            idle.SetFloat("moving", idle.GetFloat("moving") + Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            idle.SetFloat("moving", idle.GetFloat("moving") + Time.deltaTime);

        }




        else if (Input.GetKey(KeyCode.W) && Input.GetMouseButtonDown(0))
        {
            idle.SetFloat("moving", idle.GetFloat("moving") + Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.S) && Input.GetMouseButtonDown(0))
        {
            idle.SetFloat("moving", idle.GetFloat("moving") + Time.deltaTime);


        }
        else if (Input.GetKey(KeyCode.A) && Input.GetMouseButtonDown(0))
        {
            idle.SetFloat("moving", idle.GetFloat("moving") + Time.deltaTime);


        }
        else if (Input.GetKey(KeyCode.D) && Input.GetMouseButtonDown(0))
        {
            idle.SetFloat("moving", idle.GetFloat("moving") + Time.deltaTime);


        }




















        else if (Input.GetKey(KeyCode.W) == false && Input.GetMouseButtonDown(0) == false)
        {
            idle.SetFloat("moving", idle.GetFloat("moving") - idle.GetFloat("moving"));

        }
        else if (Input.GetKey(KeyCode.S) == false && Input.GetMouseButtonDown(0) == false)
        {
            idle.SetFloat("moving", idle.GetFloat("moving") - idle.GetFloat("moving"));

        }
        else if (Input.GetKey(KeyCode.A) == false && Input.GetMouseButtonDown(0) == false)
        {
            idle.SetFloat("moving", idle.GetFloat("moving") - idle.GetFloat("moving"));

        }
        else if (Input.GetKey(KeyCode.D) == false && Input.GetMouseButtonDown(0) == false)
        {
            idle.SetFloat("moving", idle.GetFloat("moving") - idle.GetFloat("moving"));

        }
    }
}
