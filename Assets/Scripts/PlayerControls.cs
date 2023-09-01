using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody2D playerBody;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 10.0f;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        playerBody.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}