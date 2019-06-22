using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAreaTeleporter : MonoBehaviour
{
    [SerializeField]
    private GameEvent _event;

    [SerializeField]
    private TestKeySO KeyInfo;

    [SerializeField]
    private Vector2 respawnLocation;

    [SerializeField]
    private List<GameObject> doors;

    [SerializeField]
    private List<GameObject> keys;

    [SerializeField]
    private TestVariables vars;

    [SerializeField]
    private ScoreInt errors;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = respawnLocation;
            vars.IncreaseSpeed();
            _event.Raise();
            Debug.Log("Errors: " + errors.score);
            errors.score = 0;
            ResetDoors();
            ResetKeys();
        }
    }

    private void ResetKeys()
    {
        foreach (GameObject key in keys)
        {
            key.SetActive(true);
        }
    }

    private void ResetDoors()
    {
        foreach(GameObject door in doors)
        {
            door.SetActive(true);
        }
    }
}
