using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonHandler : MonoBehaviour
{

    
    public scoreObj scoreObj;
    public AudioSource buttonClickSound;
    // Start is called before the first frame update
    void Start()
    {
     

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        buttonClickSound.Play();
        SceneManager.LoadScene("BasicScene", LoadSceneMode.Single);
    }

    public void Exit()
    {
        buttonClickSound.Play();
        Application.Quit();
    }
    
    
}
