using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D body;

    [SerializeField] private int spe = 0;
    [SerializeField] private float dashingCooldown;

    private bool sprinting;
    private bool canDash;
    private bool dashing;
    private float dashTime;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprinting = false;
        canDash = true;
        dashing = false;
        dashTime = 0.5f;
        dashingCooldown = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Get Dash
        if (Input.GetKey(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }

        if (dashing)
        {
            return;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-spe, 0, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(spe, 0, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, spe, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, -spe, 0) * Time.deltaTime);
        }
    }

    IEnumerator Dash()
    {
        canDash = false;
        dashing = true;
        spe *= 5;
        yield return new WaitForSeconds(dashTime);
        spe /= 5;
        dashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
