using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    [SerializeField] GameObject[] _Weapons;
    [SerializeField] GameObject _WeaponHolder;
    [SerializeField] GameObject _Player;
    [SerializeField] int _CurrentWeaponIndex = 0;

    GameObject _CurrentWeapon;
    int _TotalWeapons;
    private SprintController _sprintController;


    // Start is called before the first frame update
    void Start()
    {
        _sprintController = _Player.GetComponent<SprintController>();
        _TotalWeapons = _WeaponHolder.transform.childCount;
        _Weapons = new GameObject[_TotalWeapons];

        for (int i = 0; i < _TotalWeapons; i++)
        {
            _Weapons[i] = _WeaponHolder.transform.GetChild(i).gameObject;
            _Weapons[i].SetActive(false);
        }

        _Weapons[_CurrentWeaponIndex].SetActive(true);
        _CurrentWeapon = _Weapons[_CurrentWeaponIndex];
    }

    void Update()
    {
        
        if (_sprintController != null && _sprintController.IsSprinting())
            _Weapons[_CurrentWeaponIndex].SetActive(false);
        else
            _Weapons[_CurrentWeaponIndex].SetActive(true);

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            _Weapons[_CurrentWeaponIndex].SetActive(false);
            int _nextWeapon = _CurrentWeaponIndex + 1;
            if (_nextWeapon >= _TotalWeapons)
                _nextWeapon = 0;
            _CurrentWeaponIndex = _nextWeapon;
            _Weapons[_CurrentWeaponIndex].SetActive(true);
        }

        _WeaponHolder.transform.rotation = GetRotation();

        if (NeedsFlip()) Flip();
        else UnFlip();
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
        return MathF.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    bool NeedsFlip()
    {
        float MaxRotation = 0.5f;
        float MinRotation = -0.5f;
        float CurrentRotation = _WeaponHolder.transform.rotation.z;

        return CurrentRotation > MaxRotation || CurrentRotation < MinRotation;
    }

    void Flip()
    {
        foreach (var var in _Weapons[_CurrentWeaponIndex].GetComponentsInChildren<SpriteRenderer>())
        {
            var.flipY = true;
        }
    }

    void UnFlip()
    {
        foreach (var var in _Weapons[_CurrentWeaponIndex].GetComponentsInChildren<SpriteRenderer>())
        {
            var.flipY = false;
        }
    }

    public void GetBullets(int amount)
    {
        _Weapons[_CurrentWeaponIndex].transform.GetComponentInChildren<ShootingController>().GetBullets(amount);
    }
}
