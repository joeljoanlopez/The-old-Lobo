using System;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private GameObject healthBar = null;
    [SerializeField] private GameObject gameOver = null;
    [SerializeField] private float healthAmount = 100f;
    [SerializeField] private PauseMenu pauseMenu = null;

    private GameOverScreen _GameOverScreen;
    private HPBarController _HPBarController;
    private MoveController moveController;

    private bool isGameOver;
    private bool _isPlayer;

    private void Start()
    {
        moveController = GetComponent<MoveController>();
        _HPBarController = healthBar.GetComponent<HPBarController>();
        _GameOverScreen = gameOver.GetComponent<GameOverScreen>();

        isGameOver = false;
        _isPlayer = moveController != null; 
    }

    private void Update()
    {
        if(!isGameOver)
        {
            if (healthAmount <= 0)
            {
                if (_isPlayer)
                    GameOver();
                else
                    Destroy(this.gameObject);
            }
            if (Input.GetKey(KeyCode.Escape))            
                pauseMenu.Setup();
        }
    }

    public void TakeDamage(float damage)
    {
        print(healthAmount);
        healthAmount -= damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        print(healthAmount);
        print(damage);
        if (_isPlayer) 
            _HPBarController.UpdateBar(healthAmount);
        if (healthAmount <= 0)
            Kill();
    }

    public void Heal(float healthGained)
    {
        healthAmount += healthGained;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        _HPBarController.UpdateBar(healthAmount);
    }

    public void Kill()
    {
        healthAmount = 0;
    }

    public void GameOver()
    {
        isGameOver = true;
        _GameOverScreen.Setup();
        moveController.StopMovement();
    }

}