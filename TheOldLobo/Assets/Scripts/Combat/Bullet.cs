using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;

    [SerializeField] private float _speed = 10;
    [SerializeField] private float _damage = 20;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _lifeTime = 3f;

    private float _currentLifeTime;
    private DamageController _damageController;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * _speed;
        _damageController = GetComponent<DamageController>();
        _currentLifeTime = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Transform hit = other.gameObject.transform.parent;
        Transform my = this.gameObject.transform;
        Debug.Assert(hit != null);
        Debug.Assert(my != null);
        if (hit.parent.name != my.parent.name && other.gameObject.name != this.gameObject.name)
        {
            print(hit.parent.name);
            print(my.parent.name);
            _damageController.MakeDamage(_damage, hit.gameObject);
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        _currentLifeTime += Time.deltaTime;
        if (_currentLifeTime > _lifeTime)
            Destroy(this.gameObject);
    }
}