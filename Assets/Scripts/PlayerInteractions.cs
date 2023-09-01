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
        if (collision.collider.tag == "Projectile")
        {
            gameManager.deathCount += 1;
            gameManager.RespawnPlayer();
            
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
