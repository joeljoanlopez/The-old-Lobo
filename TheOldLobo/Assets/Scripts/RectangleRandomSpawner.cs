using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleRandomSpawner : MonoBehaviour
{
    [SerializeField] GameObject _SpawnObject;
    [SerializeField] Transform _SpawnParent;
    [SerializeField] Transform _TopLeft;
    [SerializeField] Transform _BotRight;
    [SerializeField] int _PoolSize = 5;

    GameObject[] _Pool;
    int _Alive;

    // Start is called before the first frame update
    void Start()
    {
        _Pool = new GameObject[_PoolSize];
    }

    void Update()
    {
        if (_SpawnParent.childCount < _PoolSize)
        {
            Spawn(FirstNull());
        }
    }

    private void Spawn(int i)
    {
        _Pool[i] = Instantiate(_SpawnObject, GetRandomPos(), transform.rotation);
        _Pool[i].transform.parent = _SpawnParent;
    }

    private Vector2 GetRandomPos()
    {
        float x = Random.Range(_TopLeft.position.x, _BotRight.position.x);
        float y = Random.Range(_TopLeft.position.y, _BotRight.position.y);
        return new Vector2(x, y);
    }

    private int FirstNull(){
        int i = 0;
        while (i < _PoolSize && _Pool[i] != null){
            i++;
        }
        return i;
    }
}
