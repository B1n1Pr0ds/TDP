
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator playerAnimator;
    [SerializeField]private float cdBtwAttack;
    [SerializeField] private float startCdBtwAttack;
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
                    Attack();
                }
            }
            else
                cdBtwAttack -= Time.deltaTime;     
    }
    private void Attack()
    {
        playerAnimator.SetTrigger("triggerAttacking");
        Debug.Log("Attacked");
        cdBtwAttack = startCdBtwAttack;
    }
}
