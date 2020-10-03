using UnityEngine;

public class GameState : MonoBehaviour
{
    public bool Paused { get; private set; }

    [SerializeField]
    Timer timer;

    [SerializeField]
    FearMeter fear;

    [SerializeField]
    GameConfig config;

    float timerMaxSeconds;
    float generationsScared;

    private void Awake()
    {
        Paused = false;
        timerMaxSeconds = config.TimerStartSeconds;
        generationsScared = 0;
        fear.SubscribeToFearAtMax(NextLevel);
    }

    public void Play()
    {
        Paused = false;
    }

    public void Pause()
    {
        Paused = true;

    }

    public void NextLevel()
    {
        if(timerMaxSeconds > config.TimerMinSeconds)
        {
            timerMaxSeconds -= config.TimerDecrease;
            timer.UpdateMaxTime(timerMaxSeconds);
        }
        timer.RestartTimer();
        fear.IncreaseFearChallenge(config.FearMeterMaxIncrease, config.FearDecreaseIncrement);
        generationsScared++;
    }
}
