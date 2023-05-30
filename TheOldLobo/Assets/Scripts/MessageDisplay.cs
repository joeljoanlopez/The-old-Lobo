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
    public float _displayTime = 0;
    public bool _showMessage = false;

    public TextMeshProUGUI _text;

    // Start is called before the first frame update


    void Start()
    {

    }
    void Update()
    {
        _displayTime -= Time.deltaTime;

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
        _displayTime = 3;
        _text.text = _message;  
        _text.gameObject.SetActive(true);
    }
    // Update is called once per fram


}
