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
    [SerializeField] float sprintSpe = 0;
    [SerializeField] float dashPower = 0;
    [SerializeField] float dashTime = 0;
    [SerializeField] private float dashingCooldown = 0;

    //Direction handlers
    private float horizontal;
    private float vertical;
    private float vel;

    //Sprinting handlers
    private bool sprinting;

    //Dashing handlers
    private bool canDash;
    private bool dashing;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        vel = spe;
        canDash = true;
        dashing = false;
        sprinting = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
        if (Input.GetKey(KeyCode.LeftShift)) {sprinting = true;}
        else {sprinting = false;}

        if (dashing) return;
        if (canDash && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Dash());
        }


    }

    private void FixedUpdate()
    {
        if (!dashing) body.velocity = MovVector();
        if (sprinting){vel = sprintSpe;}
        else { vel = spe; }
    }

    private Vector2 MovVector()
    {
        Vector2 mov = new Vector2(horizontal, vertical).normalized;
        return mov * vel * Time.deltaTime;
    }

    private IEnumerator Dash()
    {
        dashing = true;
        canDash = false;
        sprinting = false;
        body.velocity = MovVector() * dashPower;
        yield return new WaitForSeconds(dashTime);
        dashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }


}
