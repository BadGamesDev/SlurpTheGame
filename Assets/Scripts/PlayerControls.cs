using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    GameManager gameManager;

    public Rigidbody2D playerBody;

    float horizontal;
    float vertical;

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
            Vector2 moveInput = new Vector2(horizontal, vertical).normalized;
            playerBody.velocity = moveInput * runSpeed;
        }
        else
        {
            playerBody.velocity = new Vector2 (0,0);
        }
    }
}