
using TMPro;
using UnityEngine;


public class PlayerScore : MonoBehaviour
{
    //this script is responsable to make control of the player score and life
    
    private int life;
    private int startLife=10;
    [SerializeField] private  GameObject gameOverScene;
    [SerializeField] private GameManager gameManager;


    


    public void AddScore(int _value)
    {
        gameManager.playerScore += _value;
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
        gameManager.playerDeaths += 1;
        gameManager.DisableCountTime();
        
    }
   

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.K)) 
        {
            TakeDamage(1000);
        }
        if (life <=0)
        {
            Die();
        }
    }
    private void Awake()
    {
        life = startLife;
        gameOverScene.SetActive(false);
        gameManager.EnableCountTime();
        gameManager.SetPlayer(gameObject);
    }
   
   
}
