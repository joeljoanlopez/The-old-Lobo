using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private MoveController moveController;


    public void Setup()
    {
        gameObject.SetActive(true);
        moveController.StopMovement();
    }

    public void Play(){
        gameObject.SetActive(false);
        moveController.ResumeMovement();
    }
}