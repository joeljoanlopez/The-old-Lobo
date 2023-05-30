using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingController : MonoBehaviour
{
    // bullet traits
    [SerializeField] GameObject _bullet;
    [SerializeField] GameObject _Player;
    [SerializeField] InputActionReference _shoot;
    [SerializeField] float _bulletDamage = 20;
    [SerializeField] float _coolDown = 0.5f;
    [SerializeField] float _delay = 0;
    [SerializeField] float _fireRate = 0;
    [SerializeField] int _bulletNumber = 1;
    [SerializeField] bool _isAuto = false;


    private SprintController _sprintController;
    private Vector2 bulletFw;
    private bool _shooting;
    private Rigidbody2D rb;
    float _shootTimer;
    private bool _canShoot;


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

        _shooting = _shoot.action.IsPressed();

        if (_canShoot && _shooting && !_sprintController.IsSprinting())
        {
            _canShoot = false;
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
            for (int i = 0; i < _bulletNumber; i++)
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
