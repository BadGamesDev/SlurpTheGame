using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float delay;
    public float speed;

    public int direction;

    private void Start()
    {
        if (transform.position.x < 0)
        {
            direction = 1;
        }

        else
        {
            direction = -1;
        }
    }

    private void FixedUpdate()
    {
        delay -= Time.deltaTime;

        if (delay <= 0)
        {
            MoveProjectile();
        }

        if (transform.position.x > 22 || transform.position.x < - 22)
        {
            DeleteProjectile();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Defender"))
        {
            collision.gameObject.GetComponent<Defender>().hitPoints -= 1;
            
            if (collision.gameObject.GetComponent<Defender>().hitPoints <= 0)
            {
                Destroy(collision.gameObject);
            }
            
            DeleteProjectile();
        }
    }

    void MoveProjectile()
    {
        transform.position = new Vector2(transform.position.x + direction * speed, transform.position.y);
    }

    void DeleteProjectile()
    {
        Destroy(gameObject);
    }
}

