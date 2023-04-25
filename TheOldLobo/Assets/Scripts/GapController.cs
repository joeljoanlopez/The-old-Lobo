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
        MoveController.StartDash += StartDash;
    }
    private void OnDisable()
    {
        MoveController.StopDash -= StopDash;
    }

    private void StartDash()
    {
        foreach (var collider in allColliders)
        {
            
        }
    }

    private void OnParticleSystemStopped()
    {
        foreach(var collider in allColliders)
        {
            GetComponent<Collider>().enabled = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!moveController.isInvincible())
        {

        }
    }
}
