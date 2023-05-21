
using UnityEngine;

public class HealItem: MonoBehaviour
{
    [SerializeField] private PlayerScore playerScoreScript;
    [SerializeField] private GameObject fullhpText;
    private int healAmount = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.gameObject.tag == "Player")
                if (playerScoreScript.life < playerScoreScript.startLife)
                {
                    playerScoreScript.Heal(healAmount);
                    gameObject.SetActive(false);
                    fullhpText.SetActive(false);
                }
                else if (playerScoreScript.life == playerScoreScript.startLife)
                fullhpText.SetActive(true);
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            fullhpText.SetActive(false);
    }
    


}
