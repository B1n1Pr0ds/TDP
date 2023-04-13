
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI gOScore;
    [SerializeField] private TextMeshProUGUI playTime;
    private PlayerScore playerScoreScript;

  public void RestartLlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
     void Start()
    {
        playerScoreScript = player.GetComponent<PlayerScore>();
    }
    private void Update()
    {
        ShowScore();
    }
    void ShowScore()
    {
       scoreTxt.text = "Score: " + playerScoreScript.score.ToString();
       gOScore.text = "Your Score: " + playerScoreScript.score.ToString();
       playTime.text = "Your time: " + playerScoreScript.CountTime();
    }
}
    