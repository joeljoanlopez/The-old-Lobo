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

    // Start is called before the first frame update
    void Start()
    {
        _dashController = GetComponent<DashController>();
        body = GetComponent<Rigidbody2D>();
        varSpeed = baseSpeed;
        sprinting = false;
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
    }
}
