using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleRandomSpawner : MonoBehaviour
{
    [SerializeField] GameObject _SpawnObject;
    [SerializeField] Transform _TopLeft;
    [SerializeField] Transform _BotRight;
    [SerializeField] int _PoolSize = 0;

    GameObject[] _Pool;
    int _Alive;

    // Start is called before the first frame update
    void Start()
    {
        _Pool = new GameObject[_PoolSize];
        _Alive = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _Alive = 0;
        foreach (GameObject obj in _Pool){
            if (obj != null){
                _Alive++;
            }
        }
        if (_Alive < _Pool.Length){
            Vector2 pos = GetRandomPos();
            _Pool[_Alive] = Instantiate(_SpawnObject, GetRandomPos(), transform.rotation);
            _Pool[_Alive].transform.parent = this.transform.parent;
            _Alive++;
        }
    }

    private Vector2 GetRandomPos(){
        float x = Random.Range(_TopLeft.position.x, _BotRight.position.x);
        float y = Random.Range(_TopLeft.position.y, _BotRight.position.y);
        return new Vector2(x, y);
    }
}
