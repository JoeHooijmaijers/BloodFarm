using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAreaKey : MonoBehaviour
{
    [SerializeField]
    private TestKeySO keyInfo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            keyInfo.IncreaseKeys();
            gameObject.SetActive(false);
        }
    }
}
