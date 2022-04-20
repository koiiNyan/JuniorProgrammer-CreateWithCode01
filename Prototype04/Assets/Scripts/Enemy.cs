using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody _enemyRb;
    private GameObject _player;

    public float speed;
    private int _numberOfMinionsSec = 1;
    private int _minionsSpawnTime = 2;

    public GameObject enemyPrefab;

    void Start()
    {
        _enemyRb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");


        if (gameObject.CompareTag("Boss"))
        {
            StartCoroutine(SpawnMinions());
        }

    }


    void Update()
    {
        Vector3 lookDirection = (_player.transform.position - transform.position).normalized;
        _enemyRb.AddForce(lookDirection * speed);


        if (transform.position.y < -10f) Destroy(gameObject);
    }


    private IEnumerator SpawnMinions()
    {
        while (true)
        {
            for (int i = 0; i < _numberOfMinionsSec; i++)
            {
                Instantiate(enemyPrefab, Vector3.zero, enemyPrefab.transform.rotation);
            }
            
            yield return new WaitForSeconds(_minionsSpawnTime);
        }
    }


}
