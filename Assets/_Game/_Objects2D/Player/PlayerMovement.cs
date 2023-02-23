using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody2D rb;
    private float direction;
    private float buttonDirection;
    [SerializeField] private float speed = 0.1f;
    private Vector2 position;
    private Vector2 buttonPosition;
    private bool walkingLeftButton;
    private bool walkingRightButton;

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
        Move(position);    
    
        if (direction != 0)
        {

            if (direction > 0)
                gameObject.transform.localScale = new Vector2(2, 2);


            if (direction < 0)
                gameObject.transform.localScale = new Vector2(-2, 2);
            playerAnimator.SetBool("isWalking", true);
        }
        if (direction == 0)
        {
            playerAnimator.SetBool("isWalking", false);
        }
    }
    public void MoveRightButton()
    {
        walkingRightButton = true;
    }
    public void MoveLeftButton()
    {
        walkingLeftButton = true;

    }

    private void Move(Vector2 _position)
    {
        rb.AddForce(_position, ForceMode2D.Impulse);
    }
}