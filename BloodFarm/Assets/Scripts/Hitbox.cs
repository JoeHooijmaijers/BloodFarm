using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public int damage;

    private void Start()
    {
        if(GetComponent<Combat>() != null)
        {
            damage = GetComponent<Combat>().damage;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy"))
        {
            col.GetComponent<Combat>().TakeDamage(damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Combat>().TakeDamage(damage);
        }
    }

    public void InitializeDamage(int Damage)
    {
        damage = Damage;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
