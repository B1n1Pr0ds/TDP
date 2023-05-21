
using UnityEngine;

public class GoToOtherWayScript : MonoBehaviour
{
    [SerializeField] private GameObject gttowtxt;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            gttowtxt.SetActive(true);
        }
           

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            gttowtxt.SetActive(false);
    }
}
