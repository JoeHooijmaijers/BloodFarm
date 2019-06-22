using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAreaDoor : MonoBehaviour
{
    [SerializeField]
    private TestKeySO KeyInfo;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if(KeyInfo.keyamount > 0)
            {
                KeyInfo.DecreaseKeys();
                gameObject.SetActive(false);
            }
        }
    }
}
