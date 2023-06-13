using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private MoveController moveController;

    private GameObject _Player;
    private GameObject[] _Enemies;

    public void Setup()
    {
        gameObject.SetActive(true);

        Time.timeScale = 0;
    }

    public void Play(){
        gameObject.SetActive(false);

        Time.timeScale = 1;
    }
}