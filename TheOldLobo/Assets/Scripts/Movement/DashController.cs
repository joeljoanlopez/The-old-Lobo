using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using UnityEngine.Windows;

public class DashController : MonoBehaviour
{
    //Dashing handlers
    [SerializeField] float dashPower = 0;
    [SerializeField] float dashTime = 0;
    [SerializeField] private float dashingCooldown = 0;
    private bool canDash;
    private bool dashing;
    //private Vector2 dashingFw;

    public static Action StartDash;
    public static Action StopDash;

    Animator dash;

    // Start is called before the first frame update
    void Start()
    {
        canDash = true;
        dashing = false;
        dash = GetComponent<Animator>();
    }

    private void OnDash()
    {
        if (canDash) { StartCoroutine(Dash()); }
    }

    private IEnumerator Dash()
    {
        StartDash?.Invoke();
        dashing = true;
        canDash = false;
        dash.SetBool("dash", true);
        yield return new WaitForSeconds(dashTime);
        dashing = false;
        dash.SetBool("dash", false);
        StopDash?.Invoke();
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    public bool IsDashing()
    {
        return dashing;
    }

    public float DashPower()
    {
        return dashPower;
    }

    public void CantDash()
    {
        canDash = false;
    }

    public void ResumeDash()
    {
        canDash = true;
    }
}