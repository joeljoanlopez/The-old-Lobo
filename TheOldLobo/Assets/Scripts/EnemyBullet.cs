using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject player;
    public float force = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = transform.right * force;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
