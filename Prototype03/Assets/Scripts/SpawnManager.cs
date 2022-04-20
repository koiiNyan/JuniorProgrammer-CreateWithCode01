using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 _spawnPos = new Vector3(25f, 0f, 0f);

    private float _startDelay = 5f;
    private float _repeatRate = 3f;

    private PlayerController _playerControllerScript;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", _startDelay, _repeatRate);
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        // Randomly select prefab
        int prefabIndex = Random.Range(0, obstaclePrefabs.Length);

        //Randomly select number of prefabs to spawn
        int prefabsAmount = Random.Range(1, 3);

        for (int i = 0; i < prefabsAmount; i++)
        {
            var spawnPos = i < 1 ? _spawnPos : new Vector3(_spawnPos.x, obstaclePrefabs[prefabIndex].GetComponent<BoxCollider>().size.y, _spawnPos.z);
            if (!_playerControllerScript.gameOver) Instantiate(obstaclePrefabs[prefabIndex], spawnPos, obstaclePrefabs[prefabIndex].transform.rotation);
        }
    }
}
