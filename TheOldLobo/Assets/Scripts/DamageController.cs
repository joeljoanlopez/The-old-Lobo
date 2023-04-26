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

    public void OnCollisionStay2D(Collision collision)
    {
        if (collision.gameObject == _player)
        {
            if (!_player.GetComponent<DashController>().IsDashing())
            {
                _healthManager.Kill();
            }
        }
    }
}
