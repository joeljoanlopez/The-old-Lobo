using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
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
    }

    private void ChangeState(State newState)
    {
        
    }
    void IdleUpdate()
    { }
    void WanderUpdate()
    { }
    void AttackUpdate()
    { }

}
