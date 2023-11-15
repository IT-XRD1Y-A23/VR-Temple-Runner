using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonHandler : MonoBehaviour
{
    public scoreObj scoreObj;
    public AudioSource buttonClickSound;
    public Toggle audioToggle;
    public AudioSettings audioSettings;
    // Start is called before the first frame update
    void Start()
    {

        audioToggle.onValueChanged.AddListener(ToggleAudio);
        audioToggle.isOn = audioSettings.audioDisabled;
        buttonClickSound.Stop();
    }
 
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        if(!audioSettings.audioDisabled) { buttonClickSound.Play();
        }
       
        SceneManager.LoadScene("BasicScene", LoadSceneMode.Single);
    }

    public void Exit()
    {
        if(!audioSettings.audioDisabled) {  buttonClickSound.Play();}
       
        Application.Quit();
    }
    private void ToggleAudio(bool isAudioDisabled)
    {
        if (isAudioDisabled)
        {
            // Enable audio
            audioSettings.audioDisabled = true;
        }
        else
        {
            // Disable audio
            audioSettings.audioDisabled = false;
        }
    }

}
