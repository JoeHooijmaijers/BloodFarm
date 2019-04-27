using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int bloodAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!collision.GetComponent<Combat>().isFullHealth())
            {
                collision.GetComponent<Combat>().GainHealth(bloodAmount);
                Destroy(gameObject);
            }
        }else if (collision.CompareTag("Seed"))
        {
            collision.GetComponent<Seeds>().pickupBlood(bloodAmount);
            Destroy(gameObject);
        }
    }

    public void InstantiateAmount(int amount)
    {
        bloodAmount = amount;
    }
}
