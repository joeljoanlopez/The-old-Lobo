using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM <T> where T : Enum
{
    public T _currentState;

    Dictionary<T, State> AllStates;

    public FSM(T initState)
    {
        AllStates = new Dictionary<T, State>();
        foreach (T e in System.Enum.GetValues(typeof(T)))
        {
            AllStates.Add(e, new State());
        }
    }

    public void Update()
    {
        AllStates[_currentState].OnStay?.Invoke();
    }

    public void ChangeState(T newState)
    {
        //On Exit
        AllStates[_currentState].OnExit?.Invoke();
        AllStates[newState].OnEnter?.Invoke();
        _currentState = newState;
    }

    public void SetOnStay(T state, Action f)
    {
        AllStates[state].OnStay = f;
    }
    public void SetOnEnter(T state, Action f)
    {
        AllStates[state].OnEnter = f;
    }
    public void SetOnExit(T state, Action f)
    {
        AllStates[state].OnExit = f;
    }


}
