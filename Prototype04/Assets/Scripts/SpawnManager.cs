using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject bossPrefab;
    public GameObject[] powerUpPrefabs;
    private float _spawnRange = 9f;
    public int enemyCount;
    public int waveNumber = 1;
    public int bossAppearingWave = 3;


    void Start()
    {
        SpawnEnemyWave(waveNumber);
        var randomIndex = Random.Range(0, powerUpPrefabs.Length);
        Instantiate(powerUpPrefabs[randomIndex], GenerateSpawnPosition(), powerUpPrefabs[randomIndex].transform.rotation);
    }


    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            if (waveNumber != bossAppearingWave)
            {
                SpawnEnemyWave(waveNumber);
            }
            else
            {
                bossAppearingWave += bossAppearingWave;
                Instantiate(bossPrefab, GenerateSpawnPosition(), bossPrefab.transform.rotation);
            }
            var randomIndex = Random.Range(0, powerUpPrefabs.Length);
            Instantiate(powerUpPrefabs[randomIndex], GenerateSpawnPosition(), powerUpPrefabs[randomIndex].transform.rotation);
        }
    }

    public void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i< enemiesToSpawn; i++)
        {
            var randomIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomIndex], GenerateSpawnPosition(), enemyPrefabs[randomIndex].transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-_spawnRange, _spawnRange);
        float spawnPosZ = Random.Range(-_spawnRange, _spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0f, spawnPosZ);

        return randomPos;
    }



}
