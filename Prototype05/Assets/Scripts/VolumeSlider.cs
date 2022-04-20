using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField]
    private Slider _slider;
    
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void SetVolume()
    {
        _gameManager._gameAudio.volume = _slider.value;
    }


}
