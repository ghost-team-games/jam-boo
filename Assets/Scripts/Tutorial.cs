using System.Collections;
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
    [SerializeField]
    bool alwaysShowTutorial = false;
    [Tooltip("Check this to reset first run")]
    [SerializeField]
    bool resetFirstRun= false;

    // Start is called before the first frame update
    void Awake()
    {
        if(disableTutorial)
        {
            return;
        }

        firstRun = PlayerPrefs.GetInt("firstRun", 0);
        //inTutorial = false;

        if(firstRun == 0 || alwaysShowTutorial)
        {
            PlayerPrefs.SetInt("firstRun", 1);
            RunTutorial();
        }
        //    PlayerPrefs.SetInt("HighScore", 0);
        //    //run tutorial
        //    RunTutorial();
        //}
        //else
        //{
        //    //start game
        //}
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

    void OnValidate()
    {
        if(resetFirstRun)
        {
            PlayerPrefs.SetInt("firstRun", 0);
            resetFirstRun = false;
            Debug.Log("Resetting 'firstRun' to run tutorial again");
        }
    }
}
