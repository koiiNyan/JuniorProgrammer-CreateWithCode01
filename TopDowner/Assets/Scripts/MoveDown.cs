using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    private Rigidbody _objectRb;

    private float _zDestroy = -7.5f;

    private void Start()
    {
        _objectRb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        _objectRb.AddForce(Vector3.forward * -_speed);

        if (transform.position.z < _zDestroy) Destroy(gameObject);
    }
}
