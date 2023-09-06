using UnityEngine;

public class HankEndGame : MonoBehaviour
{
    public UIManager uiManager;
    public GameManager gameManager;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            gameManager.gamePaused = true;
            uiManager.finalPanel.SetActive(true);
        }
    }
}
