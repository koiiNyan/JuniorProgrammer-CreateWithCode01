using UnityEngine;

[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]

public class ClickAndSwipe : MonoBehaviour
{
    private GameManager _gameManager;
    private Camera _camera;
    private Vector3 _mousePosition;
    private TrailRenderer _trail;
    private BoxCollider _boxCollider;
    private bool _swiping = false;


    private void Awake()
    {
        _camera = Camera.main;
        _trail = GetComponent<TrailRenderer>();
        _boxCollider = GetComponent<BoxCollider>();
        _trail.enabled = false;
        _boxCollider.enabled = false;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void UpdateMousePosition()
    {
        _mousePosition = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        transform.position = _mousePosition;
    }

    private void UpdateComponents()
    {
        _trail.enabled = _swiping;
        _boxCollider.enabled = _swiping;
    }

    private void Update()
    {
        if (_gameManager.IsGameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _swiping = true;
                UpdateComponents();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _swiping = false;
                UpdateComponents();
            }
            if (_swiping)
            {
                UpdateMousePosition();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Target>())
        {
            collision.gameObject.GetComponent<Target>().DestroyTarget();
        }
    }
}
