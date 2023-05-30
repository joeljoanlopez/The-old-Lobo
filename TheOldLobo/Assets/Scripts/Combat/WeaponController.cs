using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    [SerializeField] GameObject[] _Weapons;
    [SerializeField] GameObject _WeaponHolder;
    [SerializeField] int _CurrentWeaponIndex = 0;

    GameObject _CurrentWeapon;
    int _TotalWeapons;


    // Start is called before the first frame update
    void Start()
    {
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
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {

            _Weapons[_CurrentWeaponIndex].SetActive(false);
            int _nextWeapon = _CurrentWeaponIndex + 1;
            if (_nextWeapon >= _TotalWeapons)
                _nextWeapon = 0;
            _CurrentWeaponIndex = _nextWeapon;
            _Weapons[_CurrentWeaponIndex].SetActive(true);
        }
    }
}
