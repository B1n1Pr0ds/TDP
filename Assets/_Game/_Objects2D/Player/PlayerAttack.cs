
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator playerAnimator;
    [SerializeField]private float cdBtwAttack;
    [SerializeField] private float startCdBtwAttack;
    [SerializeField] private int playerDamage = 5;


    [SerializeField] private Transform attackPos;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask whatIsEnemy;
    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Update()
    {
 
            if (cdBtwAttack <= 0)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    Attack(playerDamage);
                }
            }
            else
                cdBtwAttack -= Time.deltaTime;     
    }
    private void Attack(int _playerDamage)
    {
        playerAnimator.SetTrigger("triggerAttacking");
        Debug.Log("Attacked");
        cdBtwAttack = startCdBtwAttack;
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(_playerDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
