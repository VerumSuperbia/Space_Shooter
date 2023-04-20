using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_Manager : MonoBehaviour
{
    public static Score_Manager instance;

    public TextMeshProUGUI scoreText;
    private int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        score = 0;
        UpdateScore();
        StartCoroutine(AddScoreOverTime());
    }
    private IEnumerator AddScoreOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            AddScore(100);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: \n" + score;
    }
    public int GetScore()
    {
        return score;
    }
}

