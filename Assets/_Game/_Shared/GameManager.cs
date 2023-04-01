
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public TextMeshPro scoreTxt;
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
    }
}
    