using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
    public MoveController moveController;

    public void Setup()
    {
        gameObject.SetActive(true);
        moveController.StopMovement();
    }

}