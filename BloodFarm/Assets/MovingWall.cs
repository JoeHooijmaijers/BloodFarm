using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirectionalMovement
{
    Horizontal = 1,
    Vertical,
    Diagonal
}
public class MovingWall : MonoBehaviour
{
    [SerializeField]
    private Vector2 originalPosition;
    [SerializeField]
    private float horizontalBoundary;
    [SerializeField]
    private float verticalBoundary;
    [SerializeField]
    private float movementSpeed;

    private bool forward = true;
    public DirectionalMovement movementDir;

    private void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if(movementDir == DirectionalMovement.Horizontal)
        {
            if (forward)
            {
                Vector2 targetPos = new Vector2(originalPosition.x + horizontalBoundary, originalPosition.y);
                transform.position = Vector2.MoveTowards(transform.position, targetPos, movementSpeed * Time.deltaTime);
                if (transform.position.x >= targetPos.x)
                {
                    forward = false;
                }
            }
            else
            {
                Vector2 targetPos = new Vector2(originalPosition.x - horizontalBoundary, originalPosition.y);
                transform.position = Vector2.MoveTowards(transform.position, targetPos, movementSpeed * Time.deltaTime);
                if (transform.position.x <= targetPos.x)
                {
                    forward = true;
                }
            }
        }else if(movementDir == DirectionalMovement.Vertical)
        {
            if (forward)
            {
                Vector2 targetPos = new Vector2(originalPosition.x, originalPosition.y + verticalBoundary);
                transform.position = Vector2.MoveTowards(transform.position, targetPos, movementSpeed * Time.deltaTime);
                if(transform.position.y >= targetPos.y)
                {
                    forward = false;
                }
                
            }
            else if( !forward)
            {
                Vector2 targetPos = new Vector2(originalPosition.x, originalPosition.y - verticalBoundary);
                transform.position = Vector2.MoveTowards(transform.position, targetPos, movementSpeed * Time.deltaTime);
                if (transform.position.y <= targetPos.y)
                {
                    forward = true;
                }
            }
        }
        else if(movementDir == DirectionalMovement.Diagonal){

        }
        else
        {
            Debug.Log("Error in Moving wall at position: " + transform.position.x + " x and " + transform.position.y);
        }
    }
}
