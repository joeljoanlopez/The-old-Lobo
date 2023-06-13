using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCamera : MonoBehaviour
{
    [SerializeField] GameObject _Cameras;
    [SerializeField] GameObject _Player;


    CameraChangeController _CameraChangeController;

    void Start()
    {
        _CameraChangeController = _Cameras.GetComponent<CameraChangeController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == _Player.name)
        {
            _CameraChangeController?.ChangeCamera(1);
        }
    }
}
