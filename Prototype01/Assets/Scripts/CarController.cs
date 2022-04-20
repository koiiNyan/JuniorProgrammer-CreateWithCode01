using UnityEngine;

public class CarController : MonoBehaviour
{
    //Private variables
    [SerializeField]
    private float _speed = 15.0f;
    private Vector3 _initialPosition;
    public Vector3 InitialPosition => _initialPosition;

    private void Start()
    {
        _initialPosition = gameObject.transform.position;
        
    }

    private void Update()
    {
        // Moves the car forward 
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
    }
}
