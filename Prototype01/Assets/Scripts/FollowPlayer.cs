using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField]
    private Vector3 _offset = new Vector3(0f, 5f, -7f);
    private Vector3 _initialRotation = new Vector3(17f, 0f, 0f);

    private Vector3 _driverView = new Vector3(0f, 1.85f, 1.35f);

    private bool _cameraSwitched = false;

    private void Update()
    {
        if (player.name == "Vehicle" && Input.GetKeyDown(KeyCode.Q)) _cameraSwitched = !_cameraSwitched;
        else if (player.name == "Vehicle (1)" && Input.GetKeyDown(KeyCode.E)) _cameraSwitched = !_cameraSwitched;
    }

    private void LateUpdate()
    {
        // Switch camera by pressing Q (1rst player) and E (2nd player)
        if (_cameraSwitched)
        {
            transform.position = player.transform.position + _driverView;
            if (transform.eulerAngles != Vector3.zero) transform.eulerAngles = Vector3.zero;
        }
        else
        {
            transform.position = player.transform.position + _offset;
            if (transform.eulerAngles != _initialRotation) transform.eulerAngles = _initialRotation;
        }
    }
}
