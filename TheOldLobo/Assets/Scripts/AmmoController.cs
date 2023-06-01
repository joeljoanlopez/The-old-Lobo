using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    int _BulletAmount;

    // Start is called before the first frame update
    void Start()
    {
        _BulletAmount = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent.gameObject.name != this.transform.parent.gameObject.name){
            other.GetComponent<WeaponController>().GetBullets(_BulletAmount);
            Destroy(gameObject);
        }
    }
}
