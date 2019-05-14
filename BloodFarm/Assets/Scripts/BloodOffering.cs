using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodOffering : MonoBehaviour
{
    [SerializeField]
    private RectTransform bloodBar;
    [SerializeField]
    private float width = 200;

    public Transform player;
    public float bloodOffered;

    public BloodState state;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bloodOffered = 0;
        UpdateBlood();
    }

    public void IncreaseOffering()
    {
        bloodOffered += 5;
        if (bloodOffered > player.GetComponent<Combat>().health)
        {
            bloodOffered = player.GetComponent<Combat>().health - 1;
        }
        UpdateBlood();
    }

    public void DecreaseOffering()
    {
        bloodOffered -= 5;
        if(bloodOffered < 0)
        {
            bloodOffered = 0;
        }
        UpdateBlood();
    }

    public void UpdateBlood()
    {
        bloodBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (bloodOffered /100) * width);
        
    }

    public void OfferBlood()
    {
        player.GetComponent<Combat>().TakeDamage((int)bloodOffered);
        state.decayRate*=1.5f;
        if (bloodOffered == 0)
        {
            return;
        }
        state.satisfaction += bloodOffered + (bloodOffered * (2 / bloodOffered));
        if (state.satisfaction > state.maxSatisfaction)
        {
            state.satisfaction = state.maxSatisfaction;
        }

        
    }
}
