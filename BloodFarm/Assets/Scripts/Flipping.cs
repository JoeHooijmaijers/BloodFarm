using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipping : MonoBehaviour
{
    private Transform parent;
    private Transform target;

    private void Start()
    {
        if (parent != null)
        {
            if (parent.position.x > transform.position.x)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }

    private void Update()
    {
        if(parent != null)
        {
            if (parent.position.x > transform.position.x)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }

    public void SetParent(Transform Parent)
    {
        parent = Parent;
    }
}
