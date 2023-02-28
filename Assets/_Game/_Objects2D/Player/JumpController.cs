using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]float jumpForce= 1f;
    private bool isGrounded;
    [SerializeField]private Transform playerFeet;
    private float checkSphere = 0.3f;
    [SerializeField] LayerMask whatIsGround;
        private void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
        
        
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(playerFeet.position, checkSphere, whatIsGround);
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
  
}
