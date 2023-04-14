using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_comtroller : MonoBehaviour
{
    //this script is reponsable to put the correct data to show in the player UI

    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI gOScore;
    [SerializeField] private TextMeshProUGUI playTime;
    [SerializeField] private TextMeshProUGUI playingTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowScore();
    }
    void ShowScore()
    {
        scoreTxt.text = "Score: " + gameManager.playerScore;
        gOScore.text = "Your Score: " + gameManager.playerScore;
        playTime.text = "Your time: " + ShowTimeInTimer(gameManager.CountTime());
        playingTime.text = ShowTimeInTimer(gameManager.CountTime());
    }
    private string ShowTimeInTimer(float playerPlayTime)
    {
        float _minutes = Mathf.FloorToInt(playerPlayTime / 60);
        float _seconds = Mathf.FloorToInt(playerPlayTime % 60);
        string _currentTime = string.Format("{00:00} : {01:00}", _minutes, _seconds);
        return _currentTime;
    }
}
