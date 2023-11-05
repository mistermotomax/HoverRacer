using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUi : MonoBehaviour
{
    public int score = 21600;
    int newScore;
    private TMP_Text text;
    void Start()
    {
        newScore = score;
        text = this.GetComponent<TMP_Text>();
    }

    public void OnUpdateScore(int points)
    {
        newScore += points;
        StopCoroutine(UpdateScore());
        StartCoroutine(UpdateScore());
    }


    IEnumerator UpdateScore()
    {
        while (score < newScore)
        {
            score++;
            text.text = "00" + score;
            yield return new WaitForEndOfFrame();
        }
    }
}
