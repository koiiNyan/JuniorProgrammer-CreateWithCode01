using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Private variables
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _rpm;
    [SerializeField]
    private float _horsePower;
    private Rigidbody _playerRb;
    [SerializeField]
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float forwardlInput;

    [SerializeField]
    private GameObject _centerOfMass;
    [SerializeField]
    private TextMeshProUGUI _speedometerText;
    [SerializeField]
    private TextMeshProUGUI _rpmText;
    [SerializeField]
    private List<WheelCollider> _allWheels;
    private int _wheelsOnGround;

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _playerRb.centerOfMass = _centerOfMass.transform.position;
    }

    private void FixedUpdate()
    {
        if (IsOnGround())
        {
            horizontalInput = gameObject.name == "Vehicle" ? Input.GetAxis("Horizontal") : Input.GetAxis("Horizontal1");
            forwardlInput = gameObject.name == "Vehicle" ? Input.GetAxis("Vertical") : Input.GetAxis("Vertical1");
            // Moves the car forward based on vertical input
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardlInput);
            // Rotates the car based on horizontal input
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            // Changed non-physic to physic movement
            _playerRb.AddRelativeForce(Vector3.forward * _horsePower * forwardlInput);

            _speed = Mathf.RoundToInt(_playerRb.velocity.magnitude * 2.237f); // For kph, change 2.237 to 3.6
            _speedometerText.text = $"Speed: {_speed} mph";

            _rpm = Mathf.Round((_speed % 30) * 40);
            _rpmText.text = $"RPM: {_rpm}";
        }


        if (Input.GetKey("1")) SceneManager.LoadSceneAsync(1);
    }

    private bool IsOnGround()
    {
        _wheelsOnGround = 0;
        foreach(WheelCollider wheel in _allWheels)
        {
            if (wheel.isGrounded) _wheelsOnGround++;
        }

        if (_wheelsOnGround == 4) return true;
        else return false;
    }
}
