using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Text mostGenerations;

    [SerializeField]
    Text generationsSurvived;

    [SerializeField]
    Text newHighScore;

    int gameScore;
    int highScore;
    void Start()
    {
        if(PlayerPrefs.GetInt("HighScore") < PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
            newHighScore.enabled = true;
        }
        else
        {
            newHighScore.enabled = false;
        }

        gameScore = PlayerPrefs.GetInt("Score");
        highScore = PlayerPrefs.GetInt("HighScore");

        generationsSurvived.text = "Generations Survived: " + gameScore;
        mostGenerations.text = "Most Generations Survived: " + highScore;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
