using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements.Experimental;

public class MainWeaponController : MonoBehaviour
{
    // bullet traits
    [SerializeField] GameObject bullet;
    [SerializeField] InputActionReference _shoot;
    [SerializeField] float bulletSpeed = 30;
    [SerializeField] float bulletDamage = 20;
    [SerializeField] float _coolDown = 0.5f;

    private SprintController _sprintController;
    private Vector2 bulletFw;
    private bool _shooting;
    private Rigidbody2D rb;
    float _shootTimer;
    private bool _canShoot;


    //if, where and when the bullet is shot
    public Transform shootingPoint;
    public Transform shootingPoint2;

    Animator shootAnimator;

    void Start()
    {
        _shootTimer = _coolDown;
        shootAnimator = GetComponent<Animator>();
        _sprintController = GetComponent<SprintController>();
    }

    // Update is called once per frame
    void Update()
    {
        _shootTimer += Time.deltaTime;
        _canShoot = _shootTimer >= _coolDown;

        _shooting = _shoot.action.IsPressed();
        
        if (_canShoot && _shooting && !_sprintController.IsSprinting())
        {
            _shootTimer = 0;
            shootAnimator.SetBool("shoot", true);
            shoot();
        }
        else
        {
            shootAnimator.SetBool("shoot", false);
        }
    }

    private void shoot()
    {
        StartCoroutine(ShootBullet(shootingPoint2, 0f));
        StartCoroutine(ShootBullet(shootingPoint, 0.2f));
    }

    IEnumerator ShootBullet(Transform pos, float time)
    {
        yield return new WaitForSeconds(time);
        GameObject _bullet = Instantiate(bullet, pos.position, GetRotation());
        _bullet.transform.parent = this.gameObject.transform.parent;
        Sonidos.playSFX("GunShot");
    }

    private Quaternion GetRotation()
    {
        //Get the Screen positions of the object and the mouse
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = GetAngleFromPoints(mouseOnScreen, positionOnScreen);

        //return the rotation
        return Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    float GetAngleFromPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    public void StopShoot()
    {
        if (!_shooting)
        {
            _canShoot = false;
        }
    }

}