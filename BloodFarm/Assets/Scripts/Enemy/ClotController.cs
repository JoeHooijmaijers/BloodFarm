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
        transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
        if(target.position.x > transform.position.x)
        {
            _renderer.flipX = false;
        }
        else
        {
            _renderer.flipX = true;
        }
    }
}
