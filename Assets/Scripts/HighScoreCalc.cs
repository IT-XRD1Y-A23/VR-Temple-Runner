
using TMPro;
using UnityEngine;

public class HighScoreCalc : MonoBehaviour
{
    private const int HighScoresCount = 4;
    private int[] _highscorePoints = new int[HighScoresCount];
    public TextMeshProUGUI[] highscorePlaceholders = new TextMeshProUGUI[HighScoresCount];
    public scoreObj myScore;

    // Start is called before the first frame update
    void Start()
    {
        LoadHighScores();
        AddNewScore(myScore.score);
    }

    private void LoadHighScores()
    {
        for (int i = 0; i < HighScoresCount; i++)
        {
            string key = "#" + (i + 1);
            if (PlayerPrefs.HasKey(key))
            {
                _highscorePoints[i] = PlayerPrefs.GetInt(key);
            }
        }
    }

    private void AddNewScore(int score)
    {
        int index = -1;
        for (int i = 0; i < _highscorePoints.Length; i++)
        {
            if (score > _highscorePoints[i])
            {
                index = i;
                break;
            }
        }

        if (index != -1)
        {
            for (int i = _highscorePoints.Length - 1; i > index; i--)
            {
                _highscorePoints[i] = _highscorePoints[i - 1];
            }
            _highscorePoints[index] = score;
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        for (int i = 0; i < _highscorePoints.Length; i++)
        {
            if (_highscorePoints[i] == 0)
            {
                highscorePlaceholders[i].transform.parent.gameObject.SetActive(false);
            }
            else
            {
                highscorePlaceholders[i].text = _highscorePoints[i].ToString();
                PlayerPrefs.SetInt("#" + (i + 1), _highscorePoints[i]);
            }
        }
        PlayerPrefs.Save();
        myScore.score = 0;
    }
}
