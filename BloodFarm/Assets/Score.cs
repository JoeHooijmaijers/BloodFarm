using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public ScoreInt currentScore;

    private float scoreInterval = 1;
    private float scoreTimer = 1;

    public Text scoreText;
    public GameEvent secondPassed;

    [SerializeField]
    bool tracking;

    private void Start()
    {
        if(scoreText == null)
        {
            scoreText = gameObject.GetComponent<Text>();
        }       
    }

    void Update()
    {
        if (tracking)
        {
            if (scoreTimer <= 0)
            {
                secondPassed.Raise();
                scoreTimer = scoreInterval;
            }
            else
            {
                scoreTimer -= Time.deltaTime;
            }
        }
        
    }

    public void UpdateScore()
    {
        scoreText.text = currentScore.score.ToString();
    }

    public void IncreaseScore(int amount)
    {
        currentScore.score += amount;
        UpdateScore();
    }
}
