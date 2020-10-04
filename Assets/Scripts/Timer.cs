using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    GameState state;

    [SerializeField]
    GameConfig config;

    [SerializeField]
    Text timerText;

    Action onTimerEnd;
    float maxTime;
    float timeRemainingSeconds;

    public void SubscribeToTimerEnd(Action handler)
    {
        onTimerEnd += handler;
    }

    public void RestartTimer()
    {
        timeRemainingSeconds = maxTime;
        UpdateUI();
    }

    public void UpdateMaxTime(float maxTime)
    {
        this.maxTime = maxTime;
    }

    private void Awake()
    {
        maxTime = config.TimerStartSeconds;
        RestartTimer();
        UpdateUI();
        onTimerEnd = () => { };
    }

    private void Update()
    {
        if(state.Paused || Mathf.Approximately(timeRemainingSeconds, 0))
        {
            return;
        }

        UpdateUI();
        timeRemainingSeconds -= Time.deltaTime;
        timeRemainingSeconds = Mathf.Max(0, timeRemainingSeconds);
        if(Mathf.Approximately(timeRemainingSeconds, 0))
        {
            onTimerEnd();
        }
    }

    private void UpdateUI()
    {
        string minutes = Mathf.FloorToInt(timeRemainingSeconds / 60).ToString();
        string seconds = (Mathf.FloorToInt(timeRemainingSeconds) % 60).ToString();

        timerText.text = string.Format("{0}:{1}", PadZero(minutes, 2), PadZero(seconds, 2));
    }

    private string PadZero(string time, int targetLength)
    {
        if(time.Length < targetLength)
        {
            return string.Format("{0}{1}", new string('0', targetLength - time.Length), time);
        }
        return time;
    }
}
