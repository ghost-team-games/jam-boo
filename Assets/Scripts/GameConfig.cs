﻿using UnityEngine;

public class GameConfig : MonoBehaviour
{
    [Header("Timer")]
    public float TimerStartSeconds = 120f;
    public float TimerMinSeconds = 30;
    public float TimerDecrease = 5;
    public float DelayBetweenLevels = 3f;

    [Header("Fear Meter")]
    public float FearDecreaseRate = 0.005f;
    public float FearIncreaseAmount = 5f;
    public int FearMax = 20;
    public float FearMeterMaxIncrease = 1;
    public float FearDecreaseIncrement = 0.0005f;
}
