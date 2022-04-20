using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody _targetRb;
    private float _minSpeed = 12f;
    private float _maxSpeed = 16f;
    private float _maxTorque = 10f;
    private float _xRange = 4f;
    private float _ySpawnPose = -2f;

    private GameManager _gameManager;

    [SerializeField]
    private int _pointValue;
    [SerializeField]
    private ParticleSystem _explosionParticle;

    private void Start()
    {
        _targetRb = GetComponent<Rigidbody>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        _targetRb.AddForce(RandomRofce(), ForceMode.Impulse);
        _targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }


    public void DestroyTarget()
    {
        if(_gameManager.IsGameActive)
        {
            Destroy(gameObject);
            Instantiate(_explosionParticle, transform.position, transform.rotation);
            _gameManager.UpdateScore(_pointValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))_gameManager.UpdateLives(1);
    }

    private Vector3 RandomRofce() => Vector3.up * Random.Range(_minSpeed, _maxSpeed);
    private float RandomTorque() => Random.Range(_maxTorque, _maxTorque);
    private Vector3 RandomSpawnPos() => new Vector3(Random.Range(-_xRange, _xRange), _ySpawnPose);
}
