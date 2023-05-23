using UnityEngine;

public class DamageController : MonoBehaviour
{
    private GameObject _player;
    private GameObject _enemy;
    private HealthManager _healthManager;
    private HealthManager _enemyHealthManager;

    public void Start()
    {
        _player = GameObject.Find("Player");
        _enemy = GameObject.Find("Enemy");
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == _player.name && !collision.GetComponent<DashController>().IsDashing())
        {
            _healthManager = _player.GetComponent<HealthManager>();
            _healthManager.Kill();
        }
    }

    public void MakeDamage(float _damage, GameObject _target)
    {
        _healthManager = _target.GetComponent<HealthManager>();
        if (_healthManager != null )
            _healthManager.TakeDamage(_damage);
    }
}