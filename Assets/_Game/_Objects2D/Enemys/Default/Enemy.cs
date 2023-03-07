
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int initialHp=10;
    private int hp;


    private void Start()
    {
        hp = initialHp;
    }
    private void Update()
    {
        if (hp <=0)
        {
            Die();
        }
    }

    public void TakeDamage(int _damage)
    {
        hp -= _damage;
        Debug.Log("Damage taken!");
    }
    private void Die()
    {
        gameObject.SetActive(false);
    }
    
}
