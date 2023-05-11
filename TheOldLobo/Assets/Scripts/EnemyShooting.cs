using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField]
    private GameObject _BulletTarget;
    public Transform bulletPos;
    private float timer;

    private void Start()
    {
        
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            timer = 0;
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, GetRotation());
    }

    private Quaternion GetRotation()
    {
        //Get the Screen positions of the object and the mouse
        Vector2 playerPos = _BulletTarget.transform.position;
        float angle = GetAngleFromPoints(playerPos, transform.position);

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
