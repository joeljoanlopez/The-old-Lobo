using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    //if, where and when the bullet is shot
    [SerializeField] private float shootingCooldown = 1;
    public Transform shootingPoint;
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
       

        onShoot();


    }

    private void onShoot()
    {
        if (Input.GetKey(KeyCode.LeftShift)) { sprinting = true; }
        else if (Input.GetKey(KeyCode.LeftAlt)) 
        {  sprinting = false;
           Instantiate(bullet, shootingPoint.position, transform.rotation);
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = _input * bulletSpeed;


        }
        else { sprinting = false; }
    }
  

}
