using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float _topBound = 30;
    private float _lowerBound = -10;
    private float _xBound = 30.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > _topBound)
        {
            // Instead of destroying the projectile when it leaves the screen
            //Destroy(gameObject);

            // Just deactivate it
            gameObject.SetActive(false);

        }

        else if (transform.position.z < _lowerBound
                    || transform.position.x < -_xBound || transform.position.x > _xBound)
        {
            if (FindObjectOfType<PlayerController>().Health != 0)
            {
                FindObjectOfType<PlayerController>().Health--;
                FindObjectOfType<PlayerController>().hpText.text = $"<b>Lives: {FindObjectOfType<PlayerController>().Health}</b>";
            }
            Debug.Log($"Lives = {FindObjectOfType<PlayerController>().Health}");
            Destroy(gameObject);
            if (FindObjectOfType<PlayerController>().Health == 0) Debug.Log("Game Over!");
        }

    }
}
