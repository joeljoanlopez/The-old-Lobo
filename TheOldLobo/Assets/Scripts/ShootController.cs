using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements.Experimental;

public class ShootController : MonoBehaviour
{
    // Start is called before the first frame update
    //inputs
    private Vector2 _input;

    // bullet traits
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletDamage;
    public GameObject bullet;
    private Vector2 bulletFw;
    private bool shooting;
    private Rigidbody2D rb;
    public float Firerate;
    float nextfire;


    //if, where and when the bullet is shot
    public Transform shootingPoint;
    public Transform shootingPoint2;

    private bool sprinting;
    private bool canShoot;
    void Start()
    {
        sprinting = false;
        canShoot = true;

    }

    // Update is called once per frame
    void Update()
    {
       

        shoot();


    }

    private void shoot()
    {
        if (Input.GetKey(KeyCode.LeftShift)) { sprinting = true; }

        else if (Input.GetKey(KeyCode.LeftAlt)) 
        {
            if (Time.time > nextfire)
            {
                sprinting = false;
                nextfire = Time.time+Firerate;
                Instantiate(bullet, shootingPoint.position, transform.rotation);

                Instantiate(bullet, shootingPoint2.position, transform.rotation);
            }


        }
        else { sprinting = false; }
    }

    

}
