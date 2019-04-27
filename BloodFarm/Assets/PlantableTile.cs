using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantableTile : MonoBehaviour
{
    public bool isFree;

    private void Start()
    {
        BecomeFree();
    }

    public void BecomeOccupied()
    {
        isFree = false;
    }

    public void BecomeFree()
    {
        isFree = true;
    }
}
