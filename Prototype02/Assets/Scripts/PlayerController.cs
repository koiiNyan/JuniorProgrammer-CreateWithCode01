using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float xRange = 15.0f;
    public float zRangeUp = 5.0f;
    public float zRangeDown = -2.0f;
    public GameObject projectilePrefab;
    private int _health = 3;
    public int score;
    public int Health { get => _health; set { _health = value; } }

    public Text hpText;
    public Text scoreText;

    private void Start()
    {
        Debug.Log($"Lives = {_health} \n Score = {score}");
    }


    // Update is called once per frame
    private void Update()
    {
        if (transform.position.x < -xRange)
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        if (transform.position.x > xRange)
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        if (transform.position.z < zRangeDown)
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeDown);
        if (transform.position.z > zRangeUp)
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeUp);


        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            // No longer necessary to Instantiate prefabs
            // Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

            // Get an object object from the pool
            GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
            if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true); // activate it
                pooledProjectile.transform.position = transform.position; // position it at player
            }
        }

        //Change scene
        if (Input.GetKey("1")) SceneManager.LoadSceneAsync(1);



    }
}
