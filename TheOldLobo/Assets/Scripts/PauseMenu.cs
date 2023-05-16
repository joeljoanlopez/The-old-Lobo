using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public MoveController moveController;

    public void Setup()
    {
        gameObject.SetActive(true);
        moveController.StopMovement();
    }
}