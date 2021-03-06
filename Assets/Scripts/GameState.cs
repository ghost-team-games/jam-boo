﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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
    Ghost ghost;

    [SerializeField]
    Text generationsCounted;

    [SerializeField]
    GameObject pauseMenu;

    float timerMaxSeconds;
    public int generationsScared;

    private void Awake()
    {
        Paused = false;
        timerMaxSeconds = config.TimerStartSeconds;
        generationsScared = 0;
        fear.SubscribeToFearAtMax(NextLevel);
    }

    private void UpdateUI()
    {
        generationsCounted.text = "Generations Haunted: " + generationsScared.ToString();
    }

    public void Play()
    {
        Paused = false;
        family.ResumeWandering();
        ghost.ResumeAnimation();
    }

    public void Pause()
    {

        Paused = true;
        family.PauseWandering();
        ghost.PauseAnimation();
    }

    public void NextLevel()
    {
        StartCoroutine(TransitionToNextLevel());
    }

    public void HauntObject(InteractableObject hauntTarget)
    {
        ghost.TravelTo(hauntTarget);
    }

    IEnumerator TransitionToNextLevel()
    {
        if (timerMaxSeconds > config.TimerMinSeconds)
        {
            timerMaxSeconds -= config.TimerDecrease;
            timer.UpdateMaxTime(timerMaxSeconds);
        }
        generationsScared++;
        UpdateUI();
        family.RunAway();

        yield return new WaitForSeconds(config.DelayBetweenLevels);

        fear.IncreaseFearChallenge(config.FearMeterMaxIncrease, config.FearDecreaseIncrement);
        timer.RestartTimer();
        family.MoveIn();
    }
}
