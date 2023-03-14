
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    //this script is responsable to make control of the player score and life
    private int score =0;
    private int life;
    private int startLife=10;

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
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)) 
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
    }
}