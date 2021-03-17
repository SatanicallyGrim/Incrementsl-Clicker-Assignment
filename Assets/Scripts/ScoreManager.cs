using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    #region Variables
    public ScoreChangedEvent scoreChanged;
    public Text scoreText;
    public Text perSecondText;
    private int score = 0;
    private int perSecond = 0;
    private float timer = 0;
    #endregion
    #region Properties
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            scoreChanged.Invoke(score);
            UpdateText();
        }
    }
    public int PerSecond
    {
        get
        {
            return perSecond;
        }
        set
        {
            perSecond = value;
            UpdateText();
        }
    }
    #endregion
    #region Functions / Methods
    //Updates the UI elements for Defense Stat and persecond
    public void UpdateText()
    {
        scoreText.text = $"Defense Stat: {score}";
        perSecondText.text = $"PerSecond: {perSecond}";
    }
    public void AddScore(int scoreToAdd)
    {
        Score += scoreToAdd;
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        // Add Time between frames to 'Timer'
        timer += Time.deltaTime;
        // Is timer at 1 second?
        if (timer >= 1)
        {
            // Apply 'persecond' to 'score'
            Score += perSecond;
            // Reset timer
            timer = 0;
        }
    }
    #endregion
}
