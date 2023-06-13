using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeController : MonoBehaviour
{
    [SerializeField] int _CurrentCameraIndex = 0;

    GameObject[] _Cameras;
    int _CameraCount;

    void Start()
    {
        _CameraCount = transform.childCount;
        _Cameras = new GameObject[_CameraCount];

        for (int i = 0; i < _CameraCount; i++)
        {
            _Cameras[i] = transform.GetChild(i).gameObject;
            _Cameras[i].SetActive(i == _CurrentCameraIndex);
        }
    }

    public void ChangeCamera(int newCam)
    {
        if (_CurrentCameraIndex != newCam)
        {
            _Cameras[newCam].SetActive(true);
            _Cameras[_CurrentCameraIndex].SetActive(false);
        }
    }

    public GameObject CurrentCamera(){
        return _Cameras[_CurrentCameraIndex];
    }

}
