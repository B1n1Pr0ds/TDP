
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator playerAnimator;
    private float attackAnimationTime;
    private bool stopAttackAnimation;
    [SerializeField]private float startAttackAnimation;
    private bool canAttack;
    [SerializeField]private float cdBtwAttack;
    [SerializeField] private float startCdBtwAttack;
    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Update()
    {
        if (attackAnimationTime <= 0)
            stopAttackAnimation = true;
        else
            attackAnimationTime -= Time.deltaTime;
        if (stopAttackAnimation)
        {
            playerAnimator.SetBool("isAttacking", false);
        }
        if (cdBtwAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Attack();
            }
        }
        else
            cdBtwAttack -= Time.deltaTime; 

    }
    private void Attack()
    {
        attackAnimationTime = startAttackAnimation;
        playerAnimator.SetBool("isAttacking", true);
        Debug.Log("Attacked");
        stopAttackAnimation= false;
        cdBtwAttack = startCdBtwAttack;
    }
}
