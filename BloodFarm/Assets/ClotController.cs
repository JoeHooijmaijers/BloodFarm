using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClotController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float movementSpeed;

    private SpriteRenderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        Vector2 targetLoc = new Vector2(0, 0);
        if(transform.position.x > target.position.x)
        {
            targetLoc.x = -1;
            _renderer.flipX = true;
        }
        else
        {
            targetLoc.x = 1;
            _renderer.flipX = false;
        }
        if(transform.position.y > target.position.y)
        {
            targetLoc.y = -1;
        }
        else
        {
            targetLoc.y = 1;
        }
        transform.Translate(targetLoc * movementSpeed * Time.deltaTime);
    }
}
