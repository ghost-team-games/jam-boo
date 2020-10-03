using System;
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
    float fear;

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

    private void UpdateFear(float? amount = null)
    {
        float increase = config.FearIncreaseAmount;
        if (amount.HasValue)
        {
            increase = amount.Value;
        }
        fear += increase;

        if(fear >= config.FearMax)
        {
            onFearAtMax();
        }
    }

    private void Awake()
    {
        onFearAtMax = ResetFear;
    }

    private void Update()
    {
        if(state.Paused)
        {
            return;
        }

        UpdateFearMeter();
        fear -= config.FearDecreaseRate;
        fear = Mathf.Max(0, fear);
    }

    private void ResetFear()
    {
        fear = 0;
    }

    private void UpdateFearMeter()
    {
        fearMeterFill.fillAmount = fear / config.FearMax;
    }
}
