using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class VRPlayerController : MonoBehaviour
{

    public ScoreHandler myScoreHandler;
    public scoreObj myScore;
    public AudioSource coinPickupSound;
    public AudioSource cubeHitSound;
    
    void Start()
    {
        myScore.score = 0;
    }

    private void OnTriggerEnter(Collider playerCollider)
    {
     
        if (playerCollider.gameObject.CompareTag("Obstacle"))
        {
            cubeHitSound.Play();
            SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
        }


        if (!playerCollider.gameObject.CompareTag("Coin")) return;
        
        Debug.Log("Coin collected");
        myScoreHandler.HitCoin();
            coinPickupSound.Play();

    }
}
