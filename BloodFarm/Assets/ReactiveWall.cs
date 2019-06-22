using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveWall : MonoBehaviour
{
    private SpriteRenderer _renderer;

    [SerializeField]
    private Sprite originalWall;

    [SerializeField]
    private Sprite altWall;

    [SerializeField]
    private ScoreInt ErrorCounter;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            _renderer.sprite = altWall;
            ErrorCounter.score += 1;
        }
    }

    public void RevertToOriginal()
    {
        _renderer.sprite = originalWall;
    }
}
