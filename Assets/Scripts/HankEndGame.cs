using System.Collections;
using System.Collections.Generic;
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
            uiManager.FinalEvent();
            uiManager.finalPanel.SetActive(true);
        }
    }
}
