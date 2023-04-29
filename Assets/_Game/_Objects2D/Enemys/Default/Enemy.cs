
using TMPro;
using UnityEngine;
using UnityEngine.Animations;

public class Enemy : MonoBehaviour
{
    [SerializeField] private PlayerScore playerScore;
    [SerializeField] private GameObject player;
    private float playerDistance;
    Vector3 scale;
    private int initialHp=10;
    private int hp;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private Transform attackPos;
    private Animator animator;
    private int scoreValue = 1;
    private bool flip;
    
    
    [SerializeField]private int damage;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackRangedistance = 0.8f;
    private float viewRange = 4;
    [SerializeField]private float speed;
    [SerializeField]private float startAtkCooldown = 1f;
    private float atkCooldown;
   

    private void Start()
    {
        hp = initialHp;
        animator = gameObject.GetComponent<Animator>();
        
    }
    private void Update()
    {
        playerDistance = Mathf.Abs(gameObject.transform.position.x - player.transform.position.x);
        
        
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
                    animator.SetTrigger("isAttacking");
                    atkCooldown = startAtkCooldown;
                }
                else
                    atkCooldown -= Time.deltaTime;
            }
            else
            {
                animator.SetBool("isWalking", false);
            }
        
        }

    }

    public void TakeDamage(int _damage)
    {
        hp -= _damage;
        Debug.Log("Damage taken!" +_damage);
    }
    private void Die()
    {
        gameObject.SetActive(false);
        playerScore.AddScore(scoreValue);
    }
   
    private void ChasePlayer()
    {
        scale = transform.localScale;
        if (flip)
        {
            if (player.transform.position.x > transform.position.x)
            {
                scale.x = Mathf.Abs(scale.x) * 1 * (flip ? -1 : 1);
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            else
            {
                scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
                transform.Translate(speed * Time.deltaTime * -1, 0, 0);
            }
        }
        if (player.transform.position.y > transform.position.y)
        {
            flip = false;
        }
        else
            flip = true;
        transform.localScale = scale;
    }
    public void Attack()
    {
        
        
        
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsPlayer);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<PlayerScore>().TakeDamage(damage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
