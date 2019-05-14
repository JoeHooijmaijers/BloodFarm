using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watering : MonoBehaviour
{
    public AudioSource source;
    public AudioClip watering;

    private void Start()
    {
        if (GetComponent<AudioSource>() != null)
        {
            source = GetComponent<AudioSource>();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Seed"))
        {
            col.GetComponent<Seeds>().Watered();
            source.PlayOneShot(watering);
        } 
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
