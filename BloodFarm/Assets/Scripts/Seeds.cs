using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeds : MonoBehaviour
{
    public int bloodRequirement;
    public int bloodGiven;
    public GameObject spawnedPlant;

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
        bloodGiven++;

        if(bloodGiven >= bloodRequirement)
        {
            Bloom();
        }
    }

    public void pickupBlood(int amount)
    {
        bloodGiven += amount;

        if (bloodGiven >= bloodRequirement)
        {
            Bloom();
        }
    }

    private void Bloom()
    {
        Instantiate(spawnedPlant, transform.position, Quaternion.identity, transform.root);
        Destroy(gameObject);
    }
}
