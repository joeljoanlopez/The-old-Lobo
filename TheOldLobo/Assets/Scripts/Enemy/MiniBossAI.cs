using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using Random = UnityEngine.Random;

public class MiniBossAI : MonoBehaviour
{
    // Start is called before the first frame update
    public enum EState
    {
        Idle,
        Wander,
        Attack,
    }

    FSM<EState> brain;

    [SerializeField] GameObject _Target;
    [SerializeField] GameObject _Bullet;
    [SerializeField] GameObject _Gun;
    [SerializeField] GameObject _Gun2;
    [SerializeField] GameObject _Gun3;


    [SerializeField] float _AggroDist = 5;
    [SerializeField] float _Speed = 1f;

    EnemyShooting _enemyShooting;
    PathFollower _pathFollower;
    float _currentTime;

    // Start is called before the first frame update
    void Start()
    {
        InitFSM();
        _currentTime = 0;
        _enemyShooting = GetComponent<EnemyShooting>();
        _pathFollower = GetComponent<PathFollower>();
    }

    private void InitFSM()
    {
        brain = new FSM<EState>(EState.Idle);
        brain.SetOnEnter(EState.Idle, () => _currentTime = 0);
        brain.SetOnEnter(EState.Wander, () => _currentTime = 0);

        brain.SetOnStay(EState.Idle, IdleUpdate);
        brain.SetOnStay(EState.Wander, WanderUpdate);
        brain.SetOnStay(EState.Attack, AttackUpdate);

    }

    // Update is called once per frame
    void Update()
    {
        brain.Update();
    }

    private void IdleUpdate()
    {
        //Execute
        _currentTime += Time.deltaTime;

        //CheckTriggers
        if (_currentTime > 2.0f)
            brain.ChangeState(EState.Wander);

        if (Vector2.Distance(transform.position, _Target.transform.position) < _AggroDist)
            brain.ChangeState(EState.Attack);
    }

    private void WanderUpdate()
    {
        //Execute
        _pathFollower.Move();

        //CheckTriggers
        if (_pathFollower.ArrivedAtWP())
        {
            _pathFollower.NextWP();
            _currentTime = 0;
            brain.ChangeState(EState.Idle);
        }

        if (Vector2.Distance(transform.position, _Target.transform.position) < _AggroDist)
            brain.ChangeState(EState.Attack);
    }

    private void AttackUpdate()
    {
        //Execute
        StartCoroutine(_enemyShooting.Shoot(_Target, _Bullet, _Gun, 0f));

        StartCoroutine(_enemyShooting.Shoot(_Target, _Bullet, _Gun2, 0.5f));

        StartCoroutine(_enemyShooting.Shoot(_Target, _Bullet, _Gun3, 0.5f));

        // MoveRandomly();
        MoveTowardsTarget();

        //Trigger
        if (Vector2.Distance(transform.position, _Target.transform.position) >= _AggroDist)
            brain.ChangeState(EState.Idle);
    }

    private void MoveTowardsTarget()
    {
        Vector3 newDirection = _Target.transform.position - transform.position;
        newDirection.Normalize();
        transform.position += newDirection * _Speed * Time.deltaTime;
    }

    private void MoveRandomly()
    {
        Vector3 _newDirection = new Vector3(Random.Range(0, 4), Random.Range(0, 4), 0);
        _newDirection.Normalize();
        transform.position += _newDirection * _Speed * Time.deltaTime;
    }

}

