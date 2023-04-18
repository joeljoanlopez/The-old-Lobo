using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    public float Smoothing = 0.1f;
    public Transform Player;
    private Vector3 _offset = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - Player.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        SmoothFollow();
    }

    void SimpleFollow()
    {
        transform.position = Player.position + _offset;
    }

    void SmoothFollow()
    {
        Vector3 target = Player.position;
        target.z = -10;
        transform.position = Vector3.Lerp(transform.position, target, Smoothing);
    }
}
