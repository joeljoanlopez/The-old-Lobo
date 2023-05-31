using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private MoveController moveController;

    private GameObject _Player;
    private GameObject[] _Enemies;

    public void Setup()
    {
        gameObject.SetActive(true);
        // moveController.StopMovement();

        _Player = GameObject.FindGameObjectWithTag("Player");
        _Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        _Player.SetActive(false);
        foreach(GameObject var in _Enemies){
            var.SetActive(false);
        }
    }

    public void Play(){
        gameObject.SetActive(false);
        // moveController.ResumeMovement();
        // _Player = GameObject.FindGameObjectWithTag("Player");
        // _Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        _Player.SetActive(true);
        foreach(GameObject var in _Enemies){
            var.SetActive(true);
        }
    }
}