using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] GameObject _Target;
    [SerializeField] GameObject _Bullet;
    [SerializeField] GameObject _Gun;

    EnemyShooting _enemyShooting;
    Transform _player;
    float _currentTime;
    Vector3 _direction;

    enum State
    {
        Idle,
        Wander,
        Attack
    }
    State currentState;

    private void Start()
    {
        currentState = State.Idle;
        _currentTime = 0;
        _enemyShooting = GetComponent<EnemyShooting>();

        _player = _Target.transform;
    }
    private void Update()
    {
        switch (currentState)
        {
            case State.Idle:
                IdleUpdate();
                break;
            case State.Wander:
                WanderUpdate();
                break;
            case State.Attack:
                AttackUpdate();
                break;
        }
        switch (currentState)
        {
            case State.Idle:
                break;
            case State.Wander:
                break;
            case State.Attack:
                break;
        }
    }

    private void ChangeState(State newState)
    {

    }
    void IdleUpdate()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > 2.0f)
        {
            currentState = State.Wander;
            _currentTime = 0;
            float _randomAng = Random.Range(0f, 360f);
            _direction = new Vector3(Mathf.Sin(_randomAng), Mathf.Cos(_randomAng));
        }

        if (Vector2.Distance(transform.position, _player.position) < 4)
        {
            currentState = State.Attack;
        }
    }
    void WanderUpdate()
    {
        //Execute
        transform.position += _direction * _speed * Time.deltaTime;
        _currentTime += Time.deltaTime;

        if (_currentTime > 4.0f)
        {
            currentState = State.Idle;
            _currentTime = 0;
        }

        if (Vector2.Distance(transform.position, _player.position) < 4)
        {
            currentState = State.Attack;
        }
    }
    void AttackUpdate()
    {
        _enemyShooting.Shoot(_Target, _Bullet, _Gun);
    }

}
