using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MessageDisplay : MonoBehaviour
{
    public GameObject _player;
    public string _message;
<<<<<<< Updated upstream
    public float _displayTime = 0;
=======
    public static float _displayTime = 0;
    public bool _showMessage = false;
>>>>>>> Stashed changes

    public TextMeshProUGUI _text;

    // Start is called before the first frame update


    void Start()
    {
        _text.text = _message;  
    }
    void Update()
    {
        _displayTime -= Time.deltaTime;

        Debug.Log(_displayTime);
        if (_displayTime <= 0.0)
        {
            _text.gameObject.SetActive(false);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("trigger entered");
        if (other.gameObject == _player)
        {
           ShowMessage();
        }

    }
    void ShowMessage()
    {
<<<<<<< Updated upstream
        _displayTime = 3;
=======
        _displayTime = 10;
        _text.text = _message;  
>>>>>>> Stashed changes
        _text.gameObject.SetActive(true);
    }

    // Update is called once per fram


}
