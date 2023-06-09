using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
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
    [SerializeField] float _AggroDist = 5;
    [SerializeField] float _Speed = 1f;



    EnemyShooting _enemyShooting;
    PathFollower _pathFollower;
    float _currentTime;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        InitFSM();
        _currentTime = 0;
        _enemyShooting = GetComponent<EnemyShooting>();
        _pathFollower = GetComponent<PathFollower>();
        _Target = GameObject.Find(_Target.name);
        animator = GetComponent<Animator>();
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
        if (_currentTime > 2.0f && _pathFollower != null)
        {
            brain.ChangeState(EState.Wander);
            animator.SetBool("shoot", false);
            animator.SetBool("isMoving", true);
            animator.SetFloat("moveX", transform.position.x);


        }
        if (Vector2.Distance(transform.position, _Target.transform.position) < _AggroDist)
        {
            brain.ChangeState(EState.Attack);
            animator.SetBool("shoot", true);
            animator.SetBool("isMoving", false);
            animator.SetFloat("moveX", transform.position.x);



        }
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
            animator.SetBool("isMoving", false);
            animator.SetBool("shoot", false);

        }

        if (Vector2.Distance(transform.position, _Target.transform.position) < _AggroDist)
        {
            brain.ChangeState(EState.Attack);
            animator.SetBool("shoot", true);
            animator.SetBool("isMoving", false);


        }
    }

    private void AttackUpdate()
    {
        //Execute
        StartCoroutine(_enemyShooting.Shoot(_Target, _Bullet, _Gun, 0f));
        // MoveRandomly();
        MoveTowardsTarget();



        //Trigger
        if (Vector2.Distance(transform.position, _Target.transform.position) >= _AggroDist)
        {
            brain.ChangeState(EState.Idle);
            animator.SetBool("shoot", false);
            animator.SetBool("isMoving", false);
        }

    }

    private void MoveTowardsTarget()
    {
        Vector3 newDirection = _Target.transform.position - transform.position;
        newDirection.Normalize();
        transform.position += newDirection * _Speed * Time.deltaTime;
        animator.SetBool("isMoving", true);
        animator.SetFloat("moveX", newDirection.x);
    }

    private void MoveRandomly()
    {
        Vector3 _newDirection = new Vector3(Random.Range(0, 4), Random.Range(0, 4), 0);
        _newDirection.Normalize();
        transform.position += _newDirection * _Speed * Time.deltaTime;
        animator.SetBool("isMoving", true);
        animator.SetFloat("moveX", transform.position.x);

    }

}
