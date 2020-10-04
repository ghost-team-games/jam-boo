using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimerEnd : MonoBehaviour
{
    [SerializeField]
    Timer timer;

    [SerializeField]
    MenuController menuController;

    [SerializeField]
    GameState state;
    // Start is called before the first frame update
    void Start()
    {
        timer.SubscribeToTimerEnd(OnEnd);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnd()
    {
        menuController.LoadScene(2);
        PlayerPrefs.SetInt("Score", state.generationsScared);
    }
}
