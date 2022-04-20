using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public Slider hungerSlider;
    public int amountToBeFed;

    private int _currentFedAmount = 0;

    void Start()
    {
        hungerSlider.maxValue = amountToBeFed;
        hungerSlider.value = 0;
        hungerSlider.fillRect.gameObject.SetActive(false);
    }

    public void FeedAnimal(int amount)
    {
        _currentFedAmount += amount;
        hungerSlider.fillRect.gameObject.SetActive(true);
        hungerSlider.value = _currentFedAmount;
        if (_currentFedAmount >= amountToBeFed)
        {

            Destroy(gameObject, 0.1f);
        }
    }


}
