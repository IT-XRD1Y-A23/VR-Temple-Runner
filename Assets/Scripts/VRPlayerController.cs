using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class VRPlayerController : MonoBehaviour
{

    public ScoreHandler myScoreHandler;

    private void Start()
    {
       
    }

    private void OnTriggerEnter(Collider playerCollider)
    {
     
        if (playerCollider.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
        }


        if (!playerCollider.gameObject.CompareTag("Coin")) return;
        
        Debug.Log("Coin collected");
        myScoreHandler.HitCoin();
     
    }
}
