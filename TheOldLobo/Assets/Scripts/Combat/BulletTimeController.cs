using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletTimeController : MonoBehaviour
{
    [SerializeField] float _TimeFraction = 0.5f;
    [SerializeField] float _TotalSeconds = 3;
    [SerializeField] InputActionReference _BulletTime;

    void Update()
    {
        if (_BulletTime.action.IsInProgress() && _TotalSeconds > 0)
        {
            Time.timeScale = _TimeFraction;
            _TotalSeconds -= Time.deltaTime;
        }
        else Time.timeScale = 1;
    }
}
