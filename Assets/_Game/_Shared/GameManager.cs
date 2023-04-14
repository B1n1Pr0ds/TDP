
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

  public void RestartLlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

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
        if(shouldCountTime)
        {
            CountTime();
        }

    }
    
    public float CountTime()
    {
            playerPlayTime += Time.deltaTime;
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
}
    