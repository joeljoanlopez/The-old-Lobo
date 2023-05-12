using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    public GameOverScreen GameOverScreen;
    private bool isGameOver = false;
    public MoveController moveController;
    public ShootController shotController;
    public PauseMenu pauseMenu;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(20);
        }
        else if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Heal(20);
        }

        if (healthAmount <= 0 && !isGameOver)
        {
            isGameOver = true;
            GameOverScreen.Setup();
            moveController.StopMovement();
            
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseMenu.Setup();
        }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;

        if (healthAmount <= 0)
        {
            Kill();
        }
    }

    public void Heal(float healthGained)
    {
        healthAmount += healthGained;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Kill()
    {
        healthAmount = 0;
    }
}