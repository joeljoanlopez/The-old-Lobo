using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private PauseMenu pauseMenu;

    private GameOverScreen _GameOverScreen;
    private HealthManager _HealthManager;


    private bool _isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        _GameOverScreen = gameOver.GetComponent<GameOverScreen>();
        _HealthManager = GetComponent<HealthManager>();

        _isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            pauseMenu.Setup();
        if (_HealthManager.isDead() && !_isGameOver)
        {
            _isGameOver = true;
            _GameOverScreen.Setup();
        }

    }
}
