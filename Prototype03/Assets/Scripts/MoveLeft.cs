using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float _speed = 20f;
    private float _superSpeed = 40f;
    private PlayerController _playerControllerScript;
    private float _leftBound = -15;


    private void Start()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {

        if (!_playerControllerScript.gameOver && !_playerControllerScript.gameStart)
        {
            var speed = _playerControllerScript.superSpeedActivated ? _superSpeed : _speed;
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (transform.position.x < _leftBound && gameObject.CompareTag("Obstacle")) Destroy(gameObject);
    }
}
