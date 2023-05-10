using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
        public MoveController moveController;


        public void Setup()
        {
            gameObject.SetActive(true);
            moveController.StopMovement();
        }
}
