
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody2D rb;
    private float direction;
    [SerializeField] private float speed = 10f;
    private Vector2 position;
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

        direction = 0;

        if (walkingRightButton)
        {
            direction= 1;
            position = Vector2.right * direction * speed;
            Move(position);
        }
        else if (walkingLeftButton)
        {
            direction= -1;
            position = Vector2.right * direction * speed;
            Move(position);
        }
        else if (!walkingLeftButton && !walkingRightButton)
        {
            direction = Input.GetAxisRaw("Horizontal");
            position = Vector2.right * direction * speed;
            Move(position);
        }
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
    public void MoveRightButtonPressed()
    {
        walkingRightButton = true;
    }
    public void MoveRightButtonUnpressed()
    {
        walkingRightButton = false;
    }
    public void MoveLeftButtonPressed()
    {
        walkingLeftButton = true;

    }
    public void MoveLeftButtonUnpressed()
    {
        walkingLeftButton = false;
    }

    private void Move(Vector2 _position)
    {
        rb.AddForce(_position, ForceMode2D.Impulse);
    }
    
}