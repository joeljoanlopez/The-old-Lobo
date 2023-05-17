using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private float timer;
    private bool _canShoot;

    private void Start()
    {
        _canShoot = true;
    }

    private void Update()
    {
        if (!_canShoot)
        {
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                _canShoot = true;
                timer = 0;
            }
        }
    }

    public void Shoot(GameObject _target, GameObject _bullet, GameObject _Gun)
    {
        if (_canShoot)
        {
            GameObject bullet =  Instantiate(_bullet, _Gun.transform.position, GetRotation(_target, _Gun)) as GameObject;
            bullet.transform.parent = this.gameObject.transform.parent;
            _canShoot = false;
        }
    }

    private Quaternion GetRotation(GameObject _target, GameObject _Gun)
    {
        //Get the Screen positions of the object and the mouse
        Vector2 playerPos = _target.transform.position;
        Vector2 _GunPos = _Gun.transform.position;
        float angle = GetAngleFromPoints(playerPos, _GunPos);

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
}
