using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] int points = 0;
    [SerializeField] TMP_Text score;
    public static int high_points;
    [SerializeField] TMP_Text highscore;
    public static Score instance;

    [SerializeField] GameObject lostText;
    [SerializeField] GameObject restartButton;

    private void Awake()
    {
        instance = this;
        highscore.SetText(high_points.ToString());
    }

    public void AddPoints(int newPoints)
    {
        points += newPoints;
        score.SetText(points.ToString());
    }

    public void EndingScore()
    {
        if(points > high_points)
        {
            high_points = points;
            highscore.SetText(high_points.ToString());
        }

        lostText.SetActive(true);
        restartButton.SetActive(true);
        // points = 0;
        // score.SetText(points.ToString());
    }
}
