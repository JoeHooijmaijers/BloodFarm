using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicRenderorder : MonoBehaviour
{
    SpriteRenderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _renderer.sortingOrder = 1000;
    }
}
