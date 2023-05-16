using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float speed;
    HealthManager Player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        rb.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Player damaged");
        if (other.gameObject.name == "Player")
        {

            Player.TakeDamage(20);
            Destroy(this.gameObject);
            

        }
        if(Player.healthAmount == 0)
        {
            Player.GameOverScreen.Setup();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
