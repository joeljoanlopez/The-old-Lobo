using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] GameObject player;
    public float cameraSpeed = 1.0f;


    //[SerializeField]
    //Vector3 _offset;
    //[SerializeField]

    //float _smoothing = 0.1f;
    // Use this for initialization
    void Start()
    {

    }
    private void LateUpdate()
    {
        float posX = Mathf.Lerp(transform.position.x, player.transform.position.x, Time.deltaTime * cameraSpeed);
        float posY = Mathf.Lerp(transform.position.y, player.transform.position.y, Time.deltaTime * cameraSpeed);
        transform.position = new Vector3(posX, posY, transform.position.z);
    }
    //Update is called once per frame
    void Update()
    {
    }
    //private void FixedUpdate()
    //{
    //    SmoothFollow();

    //}
    //void SmoothFollow()
    //{
    //    Vector2 targetPosition = player.position + _offset;
    //    Vector2 actualPosition = Vector3.Lerp(transform.position, targetPosition, _smoothing);
    //    transform.position = actualPosition;
    //}
}
