using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRb;
    private GameObject _focalPoint;
    public float speed = 5.0f;
    public bool hasPowerUp = false;
    private float powerUpStrength = 15f;
    public GameObject powerUpIndicator;

    public GameObject projectilePrefab;



    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("FocalPoint");
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        _playerRb.AddForce(_focalPoint.transform.forward * forwardInput * speed);
        powerUpIndicator.transform.position = transform.position + new Vector3(0f, -0.5f, 0f);


        // Changes scene
        if (Input.GetKey("1")) SceneManager.LoadSceneAsync(1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            powerUpIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine(7));
        }

        if (other.CompareTag("PowerUpProjectile"))
        {
            hasPowerUp = true;
            powerUpIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine(4));
            StartCoroutine(PowerUpProjectile(4));
        }

        if (other.CompareTag("PowerUpJump"))
        {
            hasPowerUp = true;
            powerUpIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine(5));
            StartCoroutine(PowerUpJump());
        }
    }

    private IEnumerator PowerUpCountdownRoutine(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }

    private IEnumerator PowerUpProjectile(int times)
    {
        var timer = 1f;
        while (timer <= times)
        {
            
            var enemies = FindObjectsOfType<Enemy>();
            
            foreach (var enemy in enemies)
            {
                var projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
                projectile.GetComponent<Projectile>().enemy = enemy.gameObject;
            }

            timer ++;
            yield return new WaitForSeconds(times / times);
        }
        yield return null;
    }


    private IEnumerator PowerUpJump()
    {
        var timer = 0;
        while (timer <= 2)
        {
            _playerRb.AddForce(Vector3.up * 7, ForceMode.Impulse);
            yield return new WaitForSeconds(2);

            timer++;
        }
        yield return null;
    }



    private void OnCollisionEnter(Collision collision)
    {
        if ( (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("StrongEnemy") || collision.gameObject.CompareTag("Boss")) && hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            var awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }
}
