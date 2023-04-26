using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Image healthBar;
    public float healthAmount = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            takeDamage(20);
        }
        else if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Heal(20);
        }
        else if (healthAmount == 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    public void takeDamage(float damage)
    {
        healthAmount = healthAmount - damage;
        healthBar.fillAmount = healthAmount / 100f;
    }
    public void Heal  (float healthGained)
    {
        healthAmount = healthAmount + healthGained;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;

    }

    public void Kill()
    {
        healthAmount = 0;
    }
}
