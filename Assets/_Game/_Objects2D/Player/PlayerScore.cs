
using TMPro;
using UnityEngine;


public class PlayerScore : MonoBehaviour
{
    //this script is responsable to make control of the player score and life
    
    private int life;
    private int startLife=10;
    [SerializeField] private  GameObject gameOverScene;
    public TextMeshProUGUI timerText; 


    [Header("PlayerScoreTracking")]
        public int score = 0;
        public int playerDeaths = 0;
        public float playerPlayTime;
    private bool shouldCountTime;


    public void AddScore(int _value)
    {
        score += _value;
    }
    public void TakeDamage(int _value)
    {
        life -= _value;
    }
    public void Die()
    {
        life = 0;
        gameObject.SetActive(false);
        gameOverScene.SetActive(true);
        playerDeaths += 1;
        shouldCountTime = false;
        
    }
    private void Update()
    {
        timerText.text = CountTime();
        if (Input.GetKeyDown(KeyCode.K)) 
        {
            TakeDamage(1000);
        }
        if (life <=0)
        {
            Die();
        }
    }
    private void Start()
    {
        life = startLife;
        gameOverScene.SetActive(false);
        shouldCountTime = true;

    }
    public void EnableCountTime()
    {
        shouldCountTime = true;
    }
    public string CountTime()
    {
        if (shouldCountTime)
        {
            playerPlayTime += Time.deltaTime;
        }

        float _minutes = Mathf.FloorToInt(playerPlayTime / 60);
        float _seconds = Mathf.FloorToInt(playerPlayTime % 60);
        string _currentTime = string.Format("{00:00} : {01:00}", _minutes, _seconds);
        return _currentTime;


    }
}
