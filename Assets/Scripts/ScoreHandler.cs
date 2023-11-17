using UnityEngine;
using TMPro;
using static CubeGenerator;

public class ScoreHandler : MonoBehaviour
{
    public TextMeshPro scoreLabelInScene;
    public float initialIncreaseSpeed = 1.0f;
    public float accelerationRate = 0.1f;
    private float difficultyMultiplier;
    
    //private float currentScore = 0.0f;
    private float currentIncreaseSpeed;
    private float currentScore;
    public scoreObj myScore;

    void Start()
    {
        currentIncreaseSpeed = initialIncreaseSpeed;
        LoadDifficultyFromPrefs();
    }
    public void SetDifficulty(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.Low:
                difficultyMultiplier = 0.5f;
                break;
            case Difficulty.Medium:
                difficultyMultiplier = 1;
                break;
            case Difficulty.High:
                difficultyMultiplier = 2;
                break;
        }
        // Optional: Destroy existing objects if difficulty changes during gameplay
        // DestroyExistingObjects();
        // Generate again with new difficulty
    }
    void LoadDifficultyFromPrefs()
    {
        string savedDifficulty = PlayerPrefs.GetString("Difficulty", "Medium");
        Debug.Log("Loaded Difficulty: " + savedDifficulty); // Add this line

        switch (savedDifficulty)
        {
            case "Low":
                SetDifficulty(Difficulty.Low);
                break;
            case "Medium":
                SetDifficulty(Difficulty.Medium);
                break;
            case "High":
                SetDifficulty(Difficulty.High);
                break;
            default:
                SetDifficulty(Difficulty.Medium); // Default to Medium if something goes wrong
                break;
        }
    }

    void Update()
    {
        // Increment the score over time
        currentScore += currentIncreaseSpeed * Time.deltaTime;
        currentIncreaseSpeed += accelerationRate * Time.deltaTime;

        // Update the score object
        myScore.score = Mathf.RoundToInt(currentScore);

        // Update the UI
        scoreLabelInScene.text = "Score: " + myScore.score;

    }

    public void HitCoin()
    {
        Debug.Log("Hit coin");
        currentScore += 100 *difficultyMultiplier; // Add 100 to currentScore
        myScore.score = Mathf.RoundToInt(currentScore); // Update myScore.score
        scoreLabelInScene.text = "Score: " + myScore.score; // Update the UI
    }

    public void HitTarget()
    {
        Debug.Log("Hit Target");
        currentScore += 100; // Add 100 to currentScore
        myScore.score = Mathf.RoundToInt(currentScore); // Update myScore.score
        scoreLabelInScene.text = "Score: " + myScore.score; // Update the UI
    }
}