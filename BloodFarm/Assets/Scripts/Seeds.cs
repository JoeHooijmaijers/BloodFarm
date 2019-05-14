using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeds : MonoBehaviour
{
    public int bloodRequirement;
    public int bloodGiven;
    public GameObject spawnedPlant;

    public GameEvent watered;
    public GameEvent bloomed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Watered()
    {
        watered.Raise();
        bloodGiven++;

        if(bloodGiven >= bloodRequirement)
        {
            Bloom();
        }
    }

    public void pickupBlood(int amount)
    {
        bloodGiven += amount;
        watered.Raise();
        if (bloodGiven >= bloodRequirement)
        {
            Bloom();
        }
    }

    private void Bloom()
    {
        bloomed.Raise();
        Instantiate(spawnedPlant, transform.position, Quaternion.identity, transform.parent);
        Destroy(gameObject);
    }
}
