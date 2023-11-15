using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    public TextMeshProUGUI scoreLabel;
    public float initialIncreaseSpeed = 1.0f;
    public float accelerationRate = 0.1f;

    
    //private float currentScore = 0.0f;
    private float currentIncreaseSpeed;
    private float currentScore;
    public scoreObj myScore;

    void Start()
    {
        currentIncreaseSpeed = initialIncreaseSpeed;
    }

    void Update()
    {
        // Increment the score over time
        currentScore += currentIncreaseSpeed * Time.deltaTime;
        currentIncreaseSpeed += accelerationRate * Time.deltaTime;

        // Update the score object
        myScore.score = Mathf.RoundToInt(currentScore);

        // Update the UI
        scoreLabel.text = "Score: " + myScore.score;
    }

    public void HitCoin()
    {
        Debug.Log("Hit coin");
        currentScore += 100; // Add 100 to currentScore
        myScore.score = Mathf.RoundToInt(currentScore); // Update myScore.score
        scoreLabel.text = "Score: " + myScore.score; // Update the UI
    }
}