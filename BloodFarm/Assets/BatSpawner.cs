﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawner : MonoBehaviour
{
    public GameObject bat;
    
    public void SpawnBat()
    {
        Instantiate(bat, transform.position, Quaternion.identity);
    }
}
