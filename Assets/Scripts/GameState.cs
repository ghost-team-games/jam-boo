using System.Collections;
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

    [SerializeField]
    FamilyBehaviour family;

    [SerializeField]
    Tutorial tutorial;

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
        StartCoroutine(TransitionToNextLevel());
    }

    IEnumerator TransitionToNextLevel()
    {
        if (timerMaxSeconds > config.TimerMinSeconds)
        {
            timerMaxSeconds -= config.TimerDecrease;
            timer.UpdateMaxTime(timerMaxSeconds);
        }
        timer.RestartTimer();
        fear.IncreaseFearChallenge(config.FearMeterMaxIncrease, config.FearDecreaseIncrement);
        generationsScared++;
        family.RunAway();
        Pause();

        yield return new WaitForSeconds(config.DelayBetweenLevels);

        family.MoveIn();
        Play();
    }
}
