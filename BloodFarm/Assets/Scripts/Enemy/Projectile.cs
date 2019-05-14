using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2 targetPos;
    private Vector2 position;
    [SerializeField]
    private bool rotating;

    [SerializeField]
    private float maxDuration;

    private float duration;

    [SerializeField]
    private float movementSpeed;

    private SpriteRenderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        position = transform.position;
        if(duration >= maxDuration)
        {
            Die();
        }
        else
        {
            duration += Time.deltaTime;
        }
        if(position == targetPos)
        {
            Die();
        }

        transform.position = Vector2.MoveTowards(position, targetPos, movementSpeed * Time.deltaTime);
        if (rotating)
        {
            Vector2 vectorToTarget = targetPos - position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, 1);
        }
        else
        {
            if (targetPos.x > transform.position.x)
            {
                _renderer.flipX = false;
            }
            else
            {
                _renderer.flipX = true;
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
