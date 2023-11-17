using UnityEngine;
using UnityEngine.UI;

public class DifficultySelector : MonoBehaviour
{
    public Toggle lowToggle;
    public Toggle mediumToggle;
    public Toggle highToggle;

    private void Start()
    {
        // Set default difficulty or load from previous setting

        SetDifficulty(PlayerPrefs.GetString("Difficulty", "Medium"));
    }

    public void SetDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "Low":
                lowToggle.isOn = true;
                break;
            case "Medium":
                mediumToggle.isOn = true;
                break;
            case "High":
                highToggle.isOn = true;
                break;
        }

        PlayerPrefs.SetString("Difficulty", difficulty);
        PlayerPrefs.Save();

        // Implement your difficulty logic here
        Debug.Log("Difficulty set to: " + difficulty);
    }

    // Call these methods from UI
    public void SelectLow() {
        SetDifficulty("Low");
        mediumToggle.isOn = false;
        highToggle.isOn=false;
    }
    public void SelectMedium()
    {
        SetDifficulty("Medium");
        lowToggle.isOn = false;
        highToggle.isOn = false;
    }
    public void SelectHigh()
    {
        SetDifficulty("High");
        mediumToggle.isOn = false;
        lowToggle.isOn = false;
    }
}
