using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PraysCount : MonoBehaviour
{
    [SerializeField]
    private Text praysText;

    [SerializeField]
    private Text scoreText;

    public int currentScore = 0;

    void Start()
    {
        Pray.praysChange += praysChanged;
        Enemy.scoreChange += scoreChanged;
    }

    void praysChanged(int count)
    {
        praysText.text = count.ToString();
    }

    void scoreChanged(int change)
    {
        currentScore += change;
        scoreText.text = currentScore.ToString();
    }

    void OnDisable()
    {
        Pray.praysChange -= praysChanged;
        Enemy.scoreChange -= scoreChanged;
    }
}
