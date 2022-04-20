using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _targets;
    private float _spawnRate = 1f;
    private int _score;
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private TextMeshProUGUI _livesText;
    [SerializeField]
    private TextMeshProUGUI _gameOverText;
    [SerializeField]
    private Button _gameRestartButton;
    [SerializeField]
    private GameObject _titleObjects;
    [SerializeField]
    private GameObject _pauseObjects;

    public AudioSource _gameAudio;


    public bool IsGameActive;
    private bool _isGamePaused;

    private void Start()
    {
        _titleObjects.gameObject.SetActive(true);
        _gameAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Changes scene
        if (Input.GetKey("1")) SceneManager.LoadSceneAsync(1);

        if (Input.GetKeyDown(KeyCode.Escape) && IsGameActive) PauseGame();
    }


    private IEnumerator SpawnTarget()
    {
        while (IsGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);

            var index = Random.Range(0, _targets.Count);
            Instantiate(_targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        _scoreText.text = "Score: " + _score;
    }

    public void UpdateLives(int hpSubstract)
    {
        _lives -= hpSubstract;
        _livesText.text = "Lives: " + (_lives < 0? 0 : _lives);
        if (_lives <= 0) GameOver();
    }

    public void GameOver()
    {
        IsGameActive = false;
        _gameOverText.gameObject.SetActive(true);
        _gameRestartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(float difficulty)
    {
        IsGameActive = true;
        _score = 0;
        _spawnRate /= difficulty;

        UpdateScore(_score);
        UpdateLives(0);
        StartCoroutine(SpawnTarget());
        _gameOverText.gameObject.SetActive(false);
        _gameRestartButton.gameObject.SetActive(false);
        _titleObjects.gameObject.SetActive(false);
    }

    private void PauseGame()
    {
        if (_isGamePaused)
        {
            Time.timeScale = 0;
            _pauseObjects.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            _pauseObjects.gameObject.SetActive(false);
        }
        _isGamePaused = !_isGamePaused;
    }
}
