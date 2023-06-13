using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MusicTrigger : MonoBehaviour
{
    public GameObject _player;
    public float _timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("trigger entered");
        if (other.gameObject == _player)
        {
            if(_timer< 10)
            {
                Sonidos.playMusic("AMomentOfSilence");

            }
            else
            {
                Sonidos.playMusic("AnonimoConNombre");

            }
            
        }

    }
    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
    }
}
