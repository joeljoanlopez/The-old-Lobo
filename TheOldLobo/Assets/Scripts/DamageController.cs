using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _life;
    private HealthManager _healthManager;

    public void Start()
    {
        _healthManager = _life.GetComponent<HealthManager>();
    }

    public void OnTriggerStay2D (Collider2D collision)
    {
        if (collision.gameObject == _player && !collision.GetComponent<DashController>().IsDashing())
        {
            _healthManager.Kill();
        }
    }
}
