using UnityEngine;

public class TriggerComponent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Respawn")
        {
            other.gameObject.transform.position = other.gameObject.GetComponent<CarController>().InitialPosition;
        }
    }
}
