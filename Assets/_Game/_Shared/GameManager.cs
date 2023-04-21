
using UnityEngine;


public class GameManager : MonoBehaviour
{





    public static GameManager instance;


    [SerializeField] private GameObject player;
    [SerializeField] private UI_comtroller ui_controller;

    private bool shouldCountTime;
    public int playerScore;
    public int playerDeaths;
    public float playerPlayTime;


    
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
            playerPlayTime = playerPlayTime += Time.deltaTime;
        }

    }

    public float CountTime()
    {
        if (shouldCountTime)
        {
            
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
    
    public void setui_controller(UI_comtroller _ui_controller)
    {
        ui_controller = _ui_controller;
    }

}
    