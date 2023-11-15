
using UnityEngine;
using UnityEngine.SceneManagement;


public class VRPlayerController : MonoBehaviour
{

    public ScoreHandler myScoreHandler;
    public scoreObj myScore;
    public AudioSource coinPickupSound;
    public AudioSource cubeHitSound;
    public AudioSettings audioSettings;
    public AudioSource backgroundMusic;
    void Start()
    {
        myScore.score = 0;

        
        
            playMusic();
        cubeHitSound.Stop();
        coinPickupSound.Stop();
        
    }
     public void playMusic()
    {
        if (!audioSettings.audioDisabled)
        {
            Debug.Log("not disabled");
            backgroundMusic.Play();

        }
        else
        {
            Debug.Log("stop music");
            backgroundMusic.Stop();
        }
    }
    private void OnTriggerEnter(Collider playerCollider)
    {
     
        if (playerCollider.gameObject.CompareTag("Obstacle"))
        {
            if (!audioSettings.audioDisabled)
            {
                 cubeHitSound.Play();
            }

       
            SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
        }


        if (!playerCollider.gameObject.CompareTag("Coin")) return;
        
        Debug.Log("Coin collected");
        myScoreHandler.HitCoin();
        if(!audioSettings.audioDisabled) {   coinPickupSound.Play(); }
         

    }
}
