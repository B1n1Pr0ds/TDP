using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UI_comtroller : MonoBehaviour
{
    //this script is reponsable to put the correct data to show in the player UI

    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI gOScore;
    [SerializeField] private TextMeshProUGUI playTime;
    [SerializeField] private TextMeshProUGUI playingTime;
    [SerializeField] private TextMeshProUGUI playerLife;
    void Awake()
    {
       gameManager = FindObjectOfType<GameManager>();

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
        playingTime.text = ShowTimeInTimer(gameManager.playerPlayTime);
        playerLife.text = gameManager.playerLife + "/" + gameManager.playerMaxLife;
        if (gameManager.playerLife <= gameManager.playerMaxLife / 2)
            playerLife.color = Color.red;
        else
            playerLife.color = Color.white;
    }
    private string ShowTimeInTimer(float playerPlayTime)
    {
        float _minutes = Mathf.FloorToInt(playerPlayTime / 60);
        float _seconds = Mathf.FloorToInt(playerPlayTime % 60);
        string _currentTime = string.Format("{00:00} : {01:00}", _minutes, _seconds);
        return _currentTime;
    }
    public void setGameManager(GameManager _gameManager)
    {
        gameManager= _gameManager;
    }

}
