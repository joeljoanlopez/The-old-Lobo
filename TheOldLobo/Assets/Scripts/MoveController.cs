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


    //Direction handlers
    [SerializeField] private float baseSpeed = 0;
    private float varSpeed;
    private Vector2 _input;

    //Sprinting handler
    [SerializeField] float sprintSpe = 0;
    private bool sprinting;

    //Dashing handlers
    [SerializeField] float dashPower = 0;
    [SerializeField] float dashTime = 0;
    [SerializeField] private float dashingCooldown = 0;
    private bool canDash;
    private bool dashing;
    private Vector2 dashingFw;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        varSpeed = baseSpeed;
        canDash = true;
        dashing = false;
        sprinting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) { sprinting = true; }
        else { sprinting = false; }
    }

    private void FixedUpdate()
    {
        if (sprinting) { varSpeed = sprintSpe; }
        else if (dashing) { varSpeed = dashPower; }
        else { varSpeed = baseSpeed; }
        move();
    }

    private void OnMove(InputValue value)
    {
        _input = value.Get<Vector2>();
    }

    private void OnDash()
    {
        if (canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private void move()
    {
        var velocity = _input * varSpeed * Time.deltaTime;
        if (dashing) { velocity = dashingFw * varSpeed * Time.deltaTime; }
        transform.Translate(velocity);
    }

    private IEnumerator Dash()
    {
        dashingFw = _input;
        dashing = true;
        canDash = false;
        sprinting = false;
        yield return new WaitForSeconds(dashTime);
        dashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
