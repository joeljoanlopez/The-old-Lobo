using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public MoveController moveController;
    public ShootController ShootController;
    public DashController dashController;

    public void Setup()
    {
        gameObject.SetActive(true);
        moveController.StopMovement();
        ShootController.StopShoot();
        dashController.CantDash();
    }
}