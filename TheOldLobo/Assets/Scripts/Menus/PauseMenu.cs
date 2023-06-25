using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private MoveController moveController;


    private GameObject _Player;
    private GameObject[] _Enemies;

    public void Setup()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void Play(){
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}