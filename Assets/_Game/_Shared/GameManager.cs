
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI gOScore;
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
        gOScore.text = "Your Final Score: " + playerScoreScript.score.ToString();
    }
}
    