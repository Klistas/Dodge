using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{

    public TextMeshProUGUI _bestTimeUI;
    


    void Update()
    {
        
    }
     public void Activate(int bestTime)
    {
        gameObject.SetActive(true);
        _bestTimeUI.text = $"최고 기록 : {bestTime}s";

    }
}
