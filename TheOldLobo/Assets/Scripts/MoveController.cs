using System;
using System.Collections;
using System.Collections.Generic;
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

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        _dashController = GetComponent<DashController>();
        body = GetComponent<Rigidbody2D>();
        varSpeed = baseSpeed;
        sprinting = false;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
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
            animator.SetFloat("moving", animator.GetFloat("moving") + Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetFloat("moving", animator.GetFloat("moving") + Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetFloat("moving", animator.GetFloat("moving") + Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetFloat("moving", animator.GetFloat("moving") + Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W) == false)
        {
            animator.SetFloat("moving", animator.GetFloat("moving") - animator.GetFloat("moving"));
        }
        else if (Input.GetKey(KeyCode.S) == false)
        {
            animator.SetFloat("moving", animator.GetFloat("moving") - animator.GetFloat("moving"));
        }
        else if (Input.GetKey(KeyCode.A) == false)
        {
            animator.SetFloat("moving", animator.GetFloat("moving") - animator.GetFloat("moving"));
        }
        else if (Input.GetKey(KeyCode.D) == false)
        {
            animator.SetFloat("moving", animator.GetFloat("moving") - animator.GetFloat("moving"));
        }
    }
}
