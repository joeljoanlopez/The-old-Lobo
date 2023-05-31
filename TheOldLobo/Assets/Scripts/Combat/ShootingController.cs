using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingController : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] GameObject _Player;
    [SerializeField] InputActionReference _shoot;
    [SerializeField] float _coolDown = 0.5f;
    [SerializeField] float _delay = 0;
    [SerializeField] float _fireRate = 0;
    [SerializeField] int _bulletsShot = 1;
    [SerializeField] int _bulletNumber = -1;
    [SerializeField] bool _isAuto = false;


    private SprintController _sprintController;
    private Vector2 bulletFw;
    private bool _shooting;
    private Rigidbody2D rb;
    float _shootTimer;
    private bool _canShoot;
    private bool _hasBullets;


    //if, where and when the bullet is shot
    public Transform shootingPoint;

    Animator shootAnimator;

    void Start()
    {
        _shootTimer = _coolDown;
        shootAnimator = _Player.GetComponent<Animator>();
        _sprintController = _Player.GetComponent<SprintController>();
    }

    // Update is called once per frame
    void Update()
    {
        _shootTimer += Time.deltaTime;
        _canShoot = _shootTimer >= _coolDown;
        _hasBullets = _bulletNumber > 0 || _bulletNumber == -1;

        _shooting = _shoot.action.IsPressed() && _canShoot;

        if (_hasBullets && _shooting && !_sprintController.IsSprinting())
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
        if (_isAuto)
        {
            for (int i = 0; i < Math.Min(_bulletsShot, _bulletNumber); i++)
            {
                StartCoroutine(ShootBullet(shootingPoint, i * _fireRate));
            }
        }
        else
        {
            StartCoroutine(ShootBullet(shootingPoint, _delay));
        }
    }

    IEnumerator ShootBullet(Transform pos, float time)
    {
        yield return new WaitForSeconds(time);
        GameObject bullet = Instantiate(_bullet, pos.position, GetRotation());
        bullet.transform.parent = _Player.gameObject.transform.parent;
        if (_bulletNumber > 0)
            _bulletNumber--;

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
}
