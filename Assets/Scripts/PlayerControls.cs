using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    GameManager gameManager;

    public Rigidbody2D playerBody;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 10.0f;

    private void Start()
    {
        gameManager = GameObject.Find("GameController").GetComponent<GameManager>();
    }
    
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (!gameManager.gamePaused)
        {
            if (horizontal != 0 && vertical != 0)
            {
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
            }

            playerBody.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }
    }
}