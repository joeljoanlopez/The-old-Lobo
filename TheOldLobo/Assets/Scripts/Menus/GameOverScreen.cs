using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    // public MoveController moveController;
    // public WeaponController ShootController;
    // public DashController dashController;

    private GameObject _Player;
    private GameObject[] _Enemies;

    public void Setup()
    {
        gameObject.SetActive(true);
        _Player = GameObject.FindGameObjectWithTag("Player");
        _Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        _Player.SetActive(false);
        foreach(GameObject var in _Enemies){
            var.SetActive(false);
        }
        // gameObject.SetActive(true);
        // moveController.StopMovement();
        // ShootController.StopShoot();
        // dashController.CantDash();
    }
}