using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UINumbers : MonoBehaviour
{
    public ScoreInt score;
    private Text text;

    private void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        text.text = score.score.ToString();
    }
}
