using UnityEngine;

public class DamageController : MonoBehaviour
{
    private GameObject _player;
    private GameObject _enemy;
    private HealthManager _healthManager;
    private EnemyHealthManager _enemyHealthManager;

    public void Start()
    {
        _player = GameObject.Find("Player");
        _enemy = GameObject.Find("Enemy");
        _healthManager = _player.GetComponent<HealthManager>();
        _enemyHealthManager = _enemy.GetComponent<EnemyHealthManager>();
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == _player && !collision.GetComponent<DashController>().IsDashing())
        {
            _healthManager.Kill();
        }
    }

    public void MakeDamage(float _damage, GameObject _target)
    {
        if (_target.name == _enemy.name)
            _enemyHealthManager.EnemyTakeDamage(_damage);

        if(_target.name == _player.name)
            _healthManager.TakeDamage(_damage);


    }
}