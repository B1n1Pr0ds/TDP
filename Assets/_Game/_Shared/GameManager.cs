
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{





    public static GameManager instance;


    [SerializeField] private GameObject player;


    private bool shouldCountTime;
    public int playerScore;
    public int playerDeaths;
    private float playerPlayTime = 0;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);



    }

    private void Update()
    {
        if (shouldCountTime)
        {
            CountTime();
        }

    }

    public float CountTime()
    {
        if (shouldCountTime)
        {
            playerPlayTime += Time.deltaTime;
            return playerPlayTime;
        }
        else
            return playerPlayTime;
    }
    public void EnableCountTime()
    {
        shouldCountTime = true;
    }
    public void DisableCountTime()
    {
        shouldCountTime = false;
    }
    public void SetPlayer(GameObject _player)
    {
        player = _player;
    }

}
    