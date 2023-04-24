using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField]
    GameObject Sprite;
    [SerializeField] float radius = 1.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 directVector = (new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y) -
            new Vector2(gameObject.transform.position.x, gameObject.transform.position.y)).normalized;
        Sprite.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) + directVector * radius;
    }
}
