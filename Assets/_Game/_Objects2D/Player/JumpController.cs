
using UnityEngine;

public class JumpController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]float jumpForce= 15f;
    [SerializeField] float jumpInEnemyForce = 5f;
    private bool isGrounded;
    private bool enemyJump;
    [SerializeField]private Transform playerFeet;
    private float checkSphere = 0.05f;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] LayerMask whatIsEnemy;
    [SerializeField] Animator animator;
   
    [SerializeField] int jumpDamage = 5;
        private void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
        
        
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(playerFeet.position, checkSphere, whatIsGround);
        enemyJump = Physics2D.OverlapCircle(playerFeet.position, checkSphere, whatIsEnemy);
        if(enemyJump)
        {
            rb.AddForce(Vector2.up * jumpInEnemyForce, ForceMode2D.Impulse);
            
        }
        if (isGrounded)
        {
            animator.SetBool("isGoingDown", false);
            animator.SetBool("isGoingUp", false);
            if (Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
        if (!isGrounded)
        {
            if (rb.velocity.y > 0)
            {
                animator.SetBool("isGoingUp", true);
                animator.SetBool("isGoingDown", false);
            }
            if (rb.velocity.y < 0)
            {
                animator.SetBool("isGoingDown", true);
                animator.SetBool("isGoingUp", false);
            }
        }
        
    }
    public void Jump()
    {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
  
}
