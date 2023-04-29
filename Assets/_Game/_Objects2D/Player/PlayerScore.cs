
using TMPro;
using UnityEngine;


public class PlayerScore : MonoBehaviour
{
    //this script is responsable to make control of the player score and life
    
    public int life;
    public int startLife=10;
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
    public void Heal(int _value)
    {
        if (life + _value >= startLife)
            life = startLife;
        else if (life + _value < startLife)
            life += _value;
        

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
        gameManager = FindObjectOfType<GameManager>();
        life = startLife;
        gameOverScene.SetActive(false);
        gameManager.EnableCountTime();
        gameManager.SetPlayer(gameObject);
        gameManager.setPlayerScoreScript(this);
    }
    public int getLife()
    {
        return life;
    }
   public int getMaxLife()
    {
        return startLife;
    }
   
}
