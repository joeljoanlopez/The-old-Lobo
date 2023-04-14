using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private int spe = 0;

    private bool sprinting;
    private bool dashing;
    private float dashTimer;

    // Start is called before the first frame update
    void Start()
    {
        sprinting = false;
        dashing = false;
        dashTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Get Dash
        if (Input.GetKey(KeyCode.Space) && !dashing)
        {
            Dash();
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

    void Dash()
    {
        dashing = true;
        spe *= 5;
        while (dashTimer < 2)
        {
            dashTimer += Time.deltaTime;
        }
        spe /= 5;
        dashing = false;
    }
}
