using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerText : MonoBehaviour
{
    public float SurvivalTime { get; private set; }
    public bool IsOn { get; set; }
    private TextMeshProUGUI _ui;

    public float _elapsedTime;

    void Start()
    {
        _ui = GetComponent<TextMeshProUGUI>();
        IsOn = true;
    }

    void Update()
    {
        if (IsOn)
        {
            _elapsedTime += Time.deltaTime;
            SurvivalTime += Time.deltaTime;
            if (_elapsedTime >= 1.0f)
            {
                _ui.text = $"살아남은 시간 : {(int)SurvivalTime} s";
                _elapsedTime = 0.0f;
            }
        }
    }
}
