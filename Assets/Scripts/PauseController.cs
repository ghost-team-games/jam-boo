﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField]
    GameState state;

    [SerializeField]
    GameObject pauseMenu;


    public void Resume()
    {
        //Debug.Log("Resume Hit");
        state.Play();
        DisablePause();
    }

    public void QuitGame()
    {
        //Debug.Log("Quit Hit");
        Application.Quit();
    }

    public void DisablePause()
    {
        pauseMenu.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}