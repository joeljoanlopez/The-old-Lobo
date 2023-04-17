using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D body;

    [SerializeField] private float spe = 0;
    [SerializeField] float dashPower = 0;
    [SerializeField] float dashTime = 0;
    [SerializeField] private float dashingCooldown = 0;

    private float horizontal;
    private float vertical;

    private bool sprinting;

    //Dashing handlers
    private bool canDash;
    private bool dashing;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        canDash = true;
        dashing = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (dashing)
        {
            return;
        }

        if (canDash && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Dash());
        }

    }

    private void FixedUpdate()
    {
        if (!dashing)
        {
            body.velocity = MovVector();
        }
    }

    private Vector2 MovVector()
    {
        Vector2 mov = new Vector2(horizontal, vertical).normalized;
        return mov * spe * Time.deltaTime;
    }

    private IEnumerator Dash()
    {
        canDash = false;
        dashing = true;
        body.velocity = MovVector() * dashPower;
        yield return new WaitForSeconds(dashTime);
        dashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }


}
