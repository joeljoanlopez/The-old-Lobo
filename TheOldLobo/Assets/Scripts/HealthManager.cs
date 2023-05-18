using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private float healthAmount = 100f;
    [SerializeField] private PauseMenu pauseMenu;

    private GameOverScreen _GameOverScreen;
    private HPBarController _HPBarController;
    private MoveController moveController;

    private bool isGameOver;

    private void Start()
    {
        moveController = GetComponent<MoveController>();
        _HPBarController = healthBar.GetComponent<HPBarController>();
        _GameOverScreen = gameOver.GetComponent<GameOverScreen>();

        isGameOver = false;
    }

    private void Update()
    {
        if(!isGameOver)
        {
            if (healthAmount <= 0)
            {
                isGameOver = true;
                _GameOverScreen.Setup();
                moveController.StopMovement();
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
}