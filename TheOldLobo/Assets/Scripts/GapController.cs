using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GapController : MonoBehaviour
{
    public GameObject[] allColliders;

    private void OnEnable()
    {
        DashController.StartDash += StartDash;
        DashController.StopDash += StopDash;
    }
    private void OnDisable()
    {
        DashController.StopDash += StopDash;
    }

    private void StartDash()
    {
        foreach (var collider in allColliders)
        {
            collider.GetComponent<EdgeCollider2D>().enabled = false;
        }
    }
    
    private void StopDash()
    {
        foreach (var collider in allColliders)
        {
            collider.GetComponent<EdgeCollider2D>().enabled = true;
        }
    }
}
