using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody2D rb;
    private float direction;
    public float speed = 0.1f;
    private Vector2 position;
    private bool isWalking;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        direction = Input.GetAxisRaw("Horizontal");
      position = new Vector2(direction * speed, rb.velocity.y);
        rb.AddForce(position, ForceMode2D.Impulse);
        if(direction!=0)
        {
            if (direction > 0)
                gameObject.transform.localScale = new Vector2(2, 2);


            if (direction < 0)
                gameObject.transform.localScale = new Vector2(-2, 2);
            playerAnimator.SetBool("isWalking", true);
        }
        if(direction == 0)
        {
            playerAnimator.SetBool("isWalking", false);
        }

    }
}
