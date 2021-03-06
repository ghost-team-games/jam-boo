﻿using Fungus;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FearMeter : MonoBehaviour
{
    [SerializeField]
    GameConfig config;

    [SerializeField]
    GameState state;

    [SerializeField]
    Image fearMeterFill;

    Action onFearAtMax;
    int maxFear;
    float fearDecreaseRate;
    float fear;
    int temp;

    public int fearIncreaseRate;

    public void SubscribeToFearAtMax(Action handler)
    {
        onFearAtMax += handler;
    }

    public void IncreaseFear()
    {
        UpdateFear();
    }

    public void IncreaseFearByAmount(float amount)
    {
        UpdateFear(amount);
    }

    public void IncreaseFearChallenge(float maxFearIncrease, float fearDecreaseIncrement)
    {
        maxFear += state.generationsScared/4;
        fearDecreaseRate += fearDecreaseIncrement;
    }

    private void UpdateFear(float? amount = null)
    {
        float increase = config.FearIncreaseAmount;
        if(amount.HasValue)
        {
            increase = amount.Value;
        }
        fear += increase;
        UpdateFearMeter();

        if(fear >= maxFear)
        {
            onFearAtMax();
        }
    }

    private void Awake()
    {
        maxFear = config.FearMax;
        fearDecreaseRate = config.FearDecreaseRate;
        onFearAtMax += ResetFear;
    }

    private void Update()
    {
        if(state.Paused)
        {
            return;
        }

        UpdateFearMeter();
        fear -= fearDecreaseRate;
        fear = Mathf.Max(0, fear);
    }

    private void ResetFear()
    {
        StartCoroutine(ResetBuffer());
    }

    private void UpdateFearMeter()
    {
        fearMeterFill.fillAmount = fear / maxFear;
    }

    private IEnumerator ResetBuffer()
    {
        yield return new WaitForSeconds(0.25f);
        fear = 0;
    }
}
