using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
    public Text scoreText;
    public Text multipliedText;
    private PlayerController _playerControllerScript;
   
    void Start()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    void Update()
    {
        scoreText.text = $"Score: {Mathf.Round(_playerControllerScript.score)}";
        if (_playerControllerScript.superSpeedActivated) multipliedText.gameObject.SetActive(true);
        else multipliedText.gameObject.SetActive(false);
    }
}
