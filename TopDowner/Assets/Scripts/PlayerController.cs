using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;
    private Rigidbody _playerRb;

    private float zBound = 4.37f;

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
    }

    // Moves the player based on input
    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        _playerRb.AddForce(Vector3.forward * verticalInput * _speed);
        _playerRb.AddForce(Vector3.right * horizontalInput * _speed);
    }

    // Prevent the player from leaving the top or bottom of the screen
    private void ConstrainPlayerPosition()
    {
        if (transform.position.z > zBound) transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        else if (transform.position.z < -zBound) transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with enemy");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
        }
    }
}
