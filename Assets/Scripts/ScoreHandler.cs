using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreLabel;
    public float initialIncreaseSpeed = 1.0f;
    public float accelerationRate = 0.1f;

    private float currentScore = 0.0f;
    private float currentIncreaseSpeed;

    public scoreObj ScoreObj;

    void Start()
    {
        currentIncreaseSpeed = initialIncreaseSpeed;
    }

    void Update()
    {
        // Update the score based on the current speed
        currentScore += currentIncreaseSpeed * Time.deltaTime;

        // Update the TextMeshPro label
        scoreLabel.text = "Score: " + Mathf.RoundToInt(currentScore);

        // Increase the speed over time
        currentIncreaseSpeed += accelerationRate * Time.deltaTime;

        ScoreObj.score = Mathf.RoundToInt(currentScore);
    }
}
