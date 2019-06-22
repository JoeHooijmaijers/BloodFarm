using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New KeyInfo", menuName ="UserTest/KeyInfo")]
public class TestKeySO : ScriptableObject
{
    public int keyamount = 0;

    public void IncreaseKeys()
    {
        keyamount += 1;
    }

    public void DecreaseKeys()
    {
        keyamount -= 1;
    }
    private void OnEnable()
    {
        keyamount = 0;
    }
}
