using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCrossing : MonoBehaviour
{
    public Transform leftWall;
    public Transform rightWall;

    public bool borderCrossed;

    float moveSpeed = 1;

    private Vector3 leftTargetPosition;
    private Vector3 rightTargetPosition;

    private void Start()
    {
        leftTargetPosition = new Vector3(-23.5f, leftWall.position.y, leftWall.position.z);
        rightTargetPosition = new Vector3(23.5f, rightWall.position.y, rightWall.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Collider>().CompareTag("Player") || collision.GetComponent<Collider>().CompareTag("Defender"))
        {
            borderCrossed = true;
        }
    }

    private void Update()
    {
        if (borderCrossed)
        {
            MoveWalls();
        }
    }

    private void MoveWalls()
    {
        leftWall.position = Vector3.MoveTowards(leftWall.position, leftTargetPosition, moveSpeed * Time.deltaTime);
        rightWall.position = Vector3.MoveTowards(rightWall.position, rightTargetPosition, moveSpeed * Time.deltaTime);
    }
}
