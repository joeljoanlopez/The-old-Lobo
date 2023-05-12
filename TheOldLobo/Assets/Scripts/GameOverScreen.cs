using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public MoveController moveController;
    public ShootController ShootController;
    public void Setup()
    {
        gameObject.SetActive(true);
        moveController.StopMovement();
        ShootController.StopShoot();
    }

}