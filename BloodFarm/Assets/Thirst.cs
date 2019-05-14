using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thirst : MonoBehaviour
{
    public BloodState state;
    private RectTransform img;
    private float width = 200;

    public GameEvent vampMessage;
    public GameEvent bloodPunishment;

    [SerializeField]
    private float bloodcalltimer;
    [SerializeField]
    private float maxbloodcalltimer;

    void Start()
    {
        img = GetComponent<RectTransform>();
        UpdateUI();
        state.satisfaction = 200;
        state.maxSatisfaction = 200;
        state.restorationAmount = 75;
        state.decayRate = 1;
    }

    // Update is called once per frame
    void Update()
    {
        ThirstDecay();
        UpdateUI();

        if(state.satisfaction/state.maxSatisfaction < 0.2)
        {
            if(bloodcalltimer <= 0)
            {
                bloodcalltimer = maxbloodcalltimer;
                vampMessage.Raise();
            }
            bloodcalltimer -= Time.deltaTime;
        }
        else
        {
            bloodcalltimer -= Time.deltaTime;
        }

        if(state.satisfaction <= 0)
        {
            state.satisfaction = state.restorationAmount;
            state.decayRate *=2;
            bloodPunishment.Raise();
        }
    }

    public void RecoverThirst(float amount)
    {
        state.satisfaction += amount;
        if(state.satisfaction > state.maxSatisfaction)
        {
            state.satisfaction = state.maxSatisfaction;
        }
    }

    public void RecoverForcefully()
    {
        RecoverThirst(state.restorationAmount);
    }

    public void ThirstDecay()
    {
        state.satisfaction -= state.decayRate * Time.deltaTime;
    }

    private void UpdateUI()
    {
        img.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width * (state.satisfaction / state.maxSatisfaction));
    }
}
