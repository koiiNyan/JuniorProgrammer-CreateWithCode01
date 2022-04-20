using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float _timer = 0f;

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && _timer >= 1)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            _timer = 0f;
        }


        if (Input.GetKey("1")) SceneManager.LoadSceneAsync(0);
    }
}
