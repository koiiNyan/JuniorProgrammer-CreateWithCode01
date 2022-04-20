using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] animalPrefabs;
    private float _spawnRangeX = 20f;
    private float _spawnPosZ = 20f;
    private float _startDelay = 2f;
    private float _spawnInterval = 1.5f;
    private int _rotationInCornet = 90;

    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", _startDelay, _spawnInterval);
    }

    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        // Randomly generate animal index and spawn position
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos;

        int randomPosIndex = Random.Range(0, 3);
        if (randomPosIndex == 0)
        {
            spawnPos = new Vector3(Random.Range(-_spawnRangeX, _spawnRangeX), 0f, _spawnPosZ);
            Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        }
        else if (randomPosIndex == 1)
        {
            spawnPos = new Vector3(_spawnRangeX, 0f, Random.Range(0f, _spawnPosZ));
            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, -_rotationInCornet, 0));
        }
        else
        {
            spawnPos = new Vector3(-_spawnRangeX, 0f, Random.Range(0f, _spawnPosZ));
            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, _rotationInCornet, 0));
        }
    }
}
