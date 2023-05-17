using UnityEngine;

public class DamageController : MonoBehaviour
{
    private GameObject _player;
    private HealthManager _healthManager;

    public void Start()
    {
        _player = GameObject.Find("Player");
        _healthManager = _player.GetComponent<HealthManager>();
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
        if (_target.name != _player.name)
            Destroy(_target);
        else
            _healthManager.TakeDamage(_damage);

    }
}