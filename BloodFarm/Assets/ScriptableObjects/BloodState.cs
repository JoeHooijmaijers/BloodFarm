using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New BloodState", menuName ="BloodState")]
public class BloodState : ScriptableObject
{
    public float satisfaction;
    public float maxSatisfaction;

    public float restorationAmount;
    public float decayRate;
}
