﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Tutorial : MonoBehaviour
{
    private int firstRun = 0;

    public Flowchart flowchart;
    public bool inTutorial;

    [SerializeField]
    GameState state;

    [Header("Debug")]
    [SerializeField]
    bool disableTutorial = false;

    // Start is called before the first frame update
    void Awake()
    {
        if(disableTutorial)
        {
            return;
        }

        firstRun = PlayerPrefs.GetInt("firstRun");
        //inTutorial = false;

        //if(firstRun == 0)
        //{
        //    PlayerPrefs.SetInt("firstRun", 1);
        //    PlayerPrefs.SetInt("HighScore", 0);
        //    //run tutorial
        //    RunTutorial();
        //}
        //else
        //{
        //    //start game
        //}

        RunTutorial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RunTutorial()
    {
        flowchart.SendFungusMessage("StartTutorial");
        inTutorial = true;
        state.Pause();
    }

    public void EndTutorial()
    {
        state.Play();
        inTutorial = false;
    }
}
