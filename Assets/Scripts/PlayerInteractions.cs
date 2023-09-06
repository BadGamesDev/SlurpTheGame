using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameController").GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Projectile"))
        {
            gameManager.RespawnPlayer();
            gameManager.defenders.Clear();

            foreach (Transform child in transform)
            {
                gameManager.defenderNames.Add(child.gameObject.GetComponent<Defender>().defenderName);
                Destroy(child.gameObject);
            }

            gameManager.remainingLives -= 1;
            if (gameManager.remainingLives <= 0)
            {
                gameManager.DonDonationEvent();
            }
        }
    }
}
