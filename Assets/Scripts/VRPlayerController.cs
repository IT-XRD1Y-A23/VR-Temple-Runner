using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class VRPlayerController : MonoBehaviour
{
    public scoreObj myScore;
    public AudioSource coinPickupSound;
    public AudioSource cubeHitSound;
    void Start()
    {
        myScore.score = 0;
    }

    void Update()
    {
      
    }
    
    void OnTriggerEnter(Collider PlayerCollider)
    {
     
        if (PlayerCollider.gameObject.tag == "Obstacle")
        {
            
            cubeHitSound.Play();

            SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);

        }


        if (PlayerCollider.gameObject.tag == "Coin")
        {


            coinPickupSound.Play();
           

            Debug.Log("coinsss");

            myScore.score += 100;
        }
    }
}
