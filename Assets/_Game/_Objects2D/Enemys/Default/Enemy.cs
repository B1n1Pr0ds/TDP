
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private PlayerScore playerScore;
    [SerializeField] private GameObject player;
    private float playerDistance; 
    private int initialHp=10;
    private int hp;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private Transform attackPos;
    private Animator animator;
    private int scoreValue = 1;
    
    
    [SerializeField]private int damage;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackRangedistance = 0.8f;
    private float viewRange = 4;
    private float speed;
    private float startAtkCooldown = 1f;
    private float atkCooldown;
   

    private void Start()
    {
        hp = initialHp;
        animator = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        playerDistance = gameObject.transform.position.x - player.transform.position.x;
        
        if (hp <=0)
        {
            Die();
        }
        if(playerDistance < viewRange) 
        {
            ChasePlayer();
            if (playerDistance < attackRangedistance)
            {
                if (atkCooldown < 0)
                {
                    Attack(damage);
                }
                else
                    atkCooldown -= Time.deltaTime;
            }
            else
            {
                //patrol
            }
        
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
        playerScore.AddScore(scoreValue);
    }
   
    private void ChasePlayer()
    {
    
        
    }
    private void Attack(int _damage)
    {
        atkCooldown = startAtkCooldown;
        animator.SetTrigger("isAttacking");
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsPlayer);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<PlayerScore>().TakeDamage(_damage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
