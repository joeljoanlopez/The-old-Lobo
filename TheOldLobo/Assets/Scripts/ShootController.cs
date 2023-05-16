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
    [SerializeField] GameObject bullet;

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


    Animator shootAnimator;

    void Start()
    {
        sprinting = false;
        canShoot = true;
        shootAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            shoot();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            ResumeShoot();
        }
    }

    private void shoot()
    {
        if (Input.GetKey(KeyCode.LeftShift)) 
        { 
            sprinting = true;
            shootAnimator.SetBool("shoot", false);
            StopShoot();

        }
       

        else if (Input.GetMouseButtonDown(0))
        {
            sprinting = false;

            if (Input.GetMouseButtonDown(0))
            {
                if (Time.time > nextfire)
                {

                    sprinting = false;

                    nextfire = Time.time + Firerate;


                    Invoke("C", 0.2f);

                    Instantiate(bullet, shootingPoint2.position, GetRotation());

                }
            }

        }
        if (Input.GetMouseButtonDown(0))
        {
            shootAnimator.SetBool("shoot", true);

        }
        else
        {
            shootAnimator.SetBool("shoot", false);
        }
    }

    private void C()
    {
        Instantiate(bullet, shootingPoint.position, GetRotation());
    }

    private Quaternion GetRotation()
    {
        //Get the Screen positions of the object and the mouse
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = GetAngleFromPoints(mouseOnScreen, positionOnScreen);

        //return the rotation
        return Quaternion.Euler(new Vector3(0f, 0f, angle));

        //var fromVec = ;
        //var toVec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //return Quaternion.FromToRotation(fromVec, toVec);
    }

    float GetAngleFromPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    public void StopShoot()
    {
        if (!shooting)
        {
            canShoot = false;
        }
    }
    public void ResumeShoot()
    {
        canShoot = true;
    }
}