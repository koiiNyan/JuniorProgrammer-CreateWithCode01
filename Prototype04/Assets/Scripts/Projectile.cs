using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody _projectileRb;
    public GameObject enemy;

    private int xRange = 30;

    public float speed;
    void Start()
    {
        _projectileRb = GetComponent<Rigidbody>(); 
    }

    
    void Update()
    {
        if (transform.position.x > xRange || transform.position.x < -xRange) Destroy(gameObject);

        if (enemy)
        {
            Vector3 lookDirection = (enemy.transform.position - transform.position).normalized;
            _projectileRb.AddForce(lookDirection * speed, ForceMode.Impulse);
        }
        else Destroy(gameObject);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("StrongEnemy") || collision.gameObject.CompareTag("Boss")))
        {
            Destroy(gameObject);
        }
    }
}
