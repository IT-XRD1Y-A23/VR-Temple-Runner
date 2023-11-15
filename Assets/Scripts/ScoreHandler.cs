using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreLabel;
    public float initialIncreaseSpeed = 1.0f;
    public float accelerationRate = 0.1f;

    //private float currentScore = 0.0f;
    private float currentIncreaseSpeed;

    public scoreObj ScoreObj;

    void Start()
    {
        currentIncreaseSpeed = initialIncreaseSpeed;
    }

    void Update()
    {
       
        ScoreObj.score = Mathf.RoundToInt(currentIncreaseSpeed * Time.deltaTime);

        currentIncreaseSpeed += accelerationRate * Time.deltaTime;
        scoreLabel.text = "Score: " + ScoreObj.score;
    }

}
