using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Instead of destroying the projectile when it collides with an animal
        //Destroy(other.gameObject); 

        // Just deactivate the food and destroy the animal
        //if (other.tag == "Player") //other.gameObject.SetActive(false);
        
        if (gameObject.tag == "Player")
        {
            FindObjectOfType<PlayerController>().score++;
            FindObjectOfType<PlayerController>().scoreText.text = $"<b>Score: {FindObjectOfType<PlayerController>().score}</b>";
            Debug.Log($"Score = {FindObjectOfType<PlayerController>().score}");
            gameObject.SetActive(false);
            if (other != null) other.GetComponent<HungerBar>().FeedAnimal(1);
        }
    }

}
