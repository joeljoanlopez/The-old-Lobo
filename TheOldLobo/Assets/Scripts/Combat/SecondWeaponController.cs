using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SecondWeaponController : MonoBehaviour
{
    [SerializeField] private Transform _Gun;

    [SerializeField] private GameObject _bullet;
    [SerializeField] private SprintController _sprintController;
    [SerializeField] private float _bulletNumber = 3;
    [SerializeField] private float _fireRate = 0.2f;
    [SerializeField] private float _bulletRemaining = 40;
    [SerializeField] private float _coolDown = 0.5f;
    [SerializeField] private InputActionReference _shoot;

    private Vector2 bulletFw;
    private bool _shooting;
    float _shootTimer;
    bool _canShoot;



    // Start is called before the first frame update
    void Start()
    {
        _shootTimer = _coolDown;
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
            shoot();
        }
    }

    private void shoot()
    {
        for (float i = 0; i < _bulletNumber; i++)
        {
            StartCoroutine(ShootBullet(_Gun, i * _fireRate));
        }
    }

    IEnumerator ShootBullet(Transform pos, float time)
    {
        yield return new WaitForSeconds(time);
        GameObject bullet = Instantiate(_bullet, pos.position, GetRotation());
        bullet.transform.parent = this.gameObject.transform.parent;
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
