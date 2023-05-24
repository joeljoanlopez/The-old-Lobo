using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public enum EState
    {
        Idle,
        //Fase1
        Cono,
        Serpiente,
        Linea,
        Granada,
        Golpe,
        //Cambio
        Change,
        //Fase 2
        Swipe,
        TripleGolpe,
        Salto,
        Grito,
        SerpienteRapida,
        Laser,
        SaltoCentro
    }

    FSM<EState> brain;

    [SerializeField] GameObject _Target;
    [SerializeField] GameObject _Bullet;
    [SerializeField] GameObject _Gun;
    [SerializeField] float _changeTime = 2;

    private float _currentTime;
    private bool _endAttack;


    // Start is called before the first frame update
    void Start()
    {
        InitFSM();
        _currentTime = 0;
        _endAttack = false;
    }

    private void InitFSM()
    {
        brain = new FSM<EState>(EState.Idle);
        brain.SetOnEnter(EState.Idle, () => _currentTime = 0);
        brain.SetOnStay(EState.Idle, IdleUpdate);
        
        //Fase 1
        brain.SetOnEnter(EState.Cono, () => beginAttack());
        brain.SetOnEnter(EState.Serpiente, () => beginAttack());
        brain.SetOnEnter(EState.Linea, () => beginAttack());
        brain.SetOnEnter(EState.Granada, () => beginAttack());
        brain.SetOnEnter(EState.Golpe, () => beginAttack());
        
        brain.SetOnStay(EState.Cono, ConoUpdate);
        brain.SetOnStay(EState.Serpiente, SerpienteUpdate);
        brain.SetOnStay(EState.Linea, LineaUpdate);
        brain.SetOnStay(EState.Granada, GranadaUpdate);
        brain.SetOnStay(EState.Golpe, GolpeUpdate);

        //Fase 2
    }

    private void beginAttack()
    {
        _currentTime = 0;
        _endAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        brain.Update();
    }

    private void AttackChange()
    {
        int attack = Random.Range(1, 6);
        brain.ChangeState(EState.Linea);
        //switch (attack)
        //{
        //    case 1:
        //        brain.ChangeState(EState.Cono);
        //        break;
        //    case 2:
        //        brain.ChangeState(EState.Serpiente);
        //        break;
        //    case 3:
        //        brain.ChangeState(EState.Linea);
        //        break;
        //    case 4:
        //        brain.ChangeState(EState.Granada);
        //        break;
        //    case 5:
        //        brain.ChangeState(EState.Golpe);
        //        break;
        //
        //}
    }

    private void IdleUpdate()
    {
        //Execute
        print("Idle");
        _currentTime += Time.deltaTime;

        //CheckTriggers
        if (_currentTime >= _changeTime)
            AttackChange();
    }
    
    private void ConoUpdate()
    {
        //Execute
        print("Cono");
        _currentTime += Time.deltaTime;

        //CheckTriggers
        if (_currentTime >= _changeTime)
            AttackChange();
    }
    
    private void SerpienteUpdate()
    {
        //Execute
        print("Serpiente");
        _currentTime += Time.deltaTime;

        //CheckTriggers
        if (_currentTime >= _changeTime)
            AttackChange();
    }
    
    private void LineaUpdate()
    {
        //Execute
        print("Line");
        while (_currentTime >= _changeTime)
        {
            _currentTime += Time.deltaTime;
            Ray2D ray = new Ray2D();
            ray.origin = _Gun.transform.position;
            ray.direction = _Target.transform.position - _Gun.transform.forward;
            _Gun.transform.rotation = GetRotation(_Target, _Gun);
        }
        Instantiate(_Bullet, _Gun.transform.position, GetRotation(_Target, _Gun));
        _endAttack = true;

        //CheckTriggers
        if (_endAttack)
            AttackChange();
    }
    
    private void GranadaUpdate()
    {
        //Execute
        print("Granada");
        _currentTime += Time.deltaTime;

        //CheckTriggers
        if (_currentTime >= _changeTime)
            AttackChange();
    }

    private void GolpeUpdate()
    {
        //Execute
        print("Golpe");
        _currentTime += Time.deltaTime;

        //CheckTriggers
        if (_currentTime >= _changeTime)
            AttackChange();
    }

    private Quaternion GetRotation(GameObject _target, GameObject _Gun)
    {
        //Get the Screen positions of the object and the mouse
        Vector2 playerPos = _target.transform.position;
        Vector2 _GunPos = _Gun.transform.position;
        float angle = GetAngleFromPoints(playerPos, _GunPos);

        //return the rotation
        return Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    float GetAngleFromPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

}
