using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button _button;
    private GameManager _gameManager;

    [SerializeField]
    private float _difficulty;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    private void SetDifficulty()
    {
        //Debug.Log(_button.gameObject.name + " was clicked");
        _gameManager.StartGame(_difficulty);
    }
}
