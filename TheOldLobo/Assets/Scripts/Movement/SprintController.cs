using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SprintController : MonoBehaviour
{
    //Sprinting handler
    [SerializeField] private float _sprintSpe = 20;
    [SerializeField] private InputActionReference _Sprint;

    private bool sprinting;

    // Update is called once per frame
    void Update()
    {
        sprinting = _Sprint.action.IsInProgress();
    }


    public bool IsSprinting()
    {
        return sprinting;
    }

    public float Speed()
    {
        return _sprintSpe;
    }
}
