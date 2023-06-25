using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleRandomSpawner : MonoBehaviour
{
    [SerializeField] GameObject _SpawnObject;
    [SerializeField] Transform _SpawnParent;
    [SerializeField] GameObject _BossSpawn;

    [SerializeField] Transform _TopLeft;
    [SerializeField] Transform _BotRight;
    [SerializeField] int _PoolSize = 5;
    float counter = 0;

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
        if (counter < 10)
        {
            _Pool[i] = Instantiate(_SpawnObject, GetRandomPos(), transform.rotation);
            _Pool[i].transform.parent = _SpawnParent;
            counter++;

        }
        else if( counter == 10) 
        {
            _Pool[i] = Instantiate(_BossSpawn, GetRandomPos(), transform.rotation);
            _Pool[i].transform.parent = _SpawnParent;
            counter++;
            _PoolSize++;
            _PoolSize++;

        }
        else if (counter <= 25)
        {
            _Pool[i] = Instantiate(_SpawnObject, GetRandomPos(), transform.rotation);
            _Pool[i].transform.parent = _SpawnParent;
        }
        else
        {

        }

        

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
