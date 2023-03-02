
using UnityEngine;

public class JumpController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]float jumpForce= 15f;
    private bool isGrounded;
    [SerializeField]private Transform playerFeet;
    private float checkSphere = 0.05f;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] Animator animator;
        private void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
        
        
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(playerFeet.position, checkSphere, whatIsGround);
        if(isGrounded)
        {
            animator.SetBool("isGoingDown", false);
            animator.SetBool("isGoingUp", false);
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
        if (Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }
    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else
            return;
    }
  
}
