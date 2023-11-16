using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HighScoreCalc : MonoBehaviour
{
    int[] _highscorePoints                          = {0,0,0,0};
    public TextMeshProUGUI[] highscorePlaceholders = new TextMeshProUGUI[4];
    public scoreObj myScore;
    
    // Start is called before the first frame update
    void Start()
    {
        
        _highscorePoints[0] = 0;
        _highscorePoints[1] = 0;
        _highscorePoints[2] = 0;
        _highscorePoints[3] = 0;
        
        if (PlayerPrefs.HasKey("#1"))
        {
            _highscorePoints[0] = PlayerPrefs.GetInt("#1");

            if (PlayerPrefs.HasKey("#2"))
            {
                _highscorePoints[1] = PlayerPrefs.GetInt("#2");

                if (PlayerPrefs.HasKey("#3"))
                {
                    _highscorePoints[2] = PlayerPrefs.GetInt("#3");

                    if (PlayerPrefs.HasKey("#4"))
                    {
                        _highscorePoints[3] = PlayerPrefs.GetInt("#4");
                    }
                }
                
            }

        }
        AddNewScore(myScore.score);
    }

    private void AddNewScore(int score)
    {
        if (score > _highscorePoints[0])
        {
            for (int i = 1; i < _highscorePoints.Length; i++)
            {
                _highscorePoints[i] = _highscorePoints[i-1];
            }
            _highscorePoints[0] = score;
        } else if (score > _highscorePoints[1])
        {
            for (int i = 2; i < _highscorePoints.Length; i++)
            {
                _highscorePoints[i] = _highscorePoints[i-1];
            }
            _highscorePoints[1] = score;
        } else if (score > _highscorePoints[2])
        {
            for (int i = 3; i < _highscorePoints.Length; i++)
            {
                _highscorePoints[i] = _highscorePoints[i-1];
            }
            _highscorePoints[2] = score;
        } else if (score > _highscorePoints[3])
        {
            _highscorePoints[3] = score;
        }

        for (int i = 0; i < _highscorePoints.Length; i++)
        {

            if (_highscorePoints[i] == 0)
            {
                highscorePlaceholders[i].transform.parent.gameObject.SetActive(false);
            }
            else
            {
                PlayerPrefs.SetInt("#"+(i+1),_highscorePoints[i]);
            
                highscorePlaceholders[i].text = _highscorePoints[i].ToString();
            }
        }
        PlayerPrefs.Save();
        myScore.score = 0;
    }
}
