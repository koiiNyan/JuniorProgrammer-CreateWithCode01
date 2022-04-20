using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemyPrefabs;
    [SerializeField]
    private GameObject _powerUpPrefab;

    private float _zSpawnRange = 4.5f;
    private float _xSpawnRange = 8f;
    private float _ySpawn = 1f;

    [SerializeField]
    private float _enemySpawnTime = 2f;
    [SerializeField]
    private float _powerUpSpawnTime = 5f;

    private float _startDelay = 1f;

   
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", _startDelay, _enemySpawnTime);
        InvokeRepeating("SpawnPowerUp", _startDelay, _powerUpSpawnTime);
    }



    void Update()
    {

    }

    private void SpawnEnemy()
    {
        float randomX = Random.Range(-_xSpawnRange, _xSpawnRange);
        int randomIndex = Random.Range(0, _enemyPrefabs.Length);
        var spawnPos = new Vector3(randomX, _ySpawn, _zSpawnRange);

        Instantiate(_enemyPrefabs[randomIndex], spawnPos, _enemyPrefabs[randomIndex].transform.rotation);

    }

    private void SpawnPowerUp()
    {
        float randomX = Random.Range(-_xSpawnRange, _xSpawnRange);
        float randomZ = Random.Range(-_zSpawnRange, _zSpawnRange);

        var spawnPos = new Vector3(randomX, _ySpawn, randomZ);

        Instantiate(_powerUpPrefab, spawnPos, _powerUpPrefab.transform.rotation);

    }
}
