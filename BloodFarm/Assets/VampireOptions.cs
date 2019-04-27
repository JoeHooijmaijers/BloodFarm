using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireOptions : MonoBehaviour
{
    public bool inRange;

    public GameEvent paused;
    public GameEvent unpaused;

    public GameEvent storeOpened;
    public GameEvent storeClosed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                paused.Raise();
                storeOpened.Raise();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            inRange = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
