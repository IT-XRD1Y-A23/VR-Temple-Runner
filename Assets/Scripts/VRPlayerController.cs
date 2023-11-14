using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class VRPlayerController : MonoBehaviour
{

    public scoreObj myScore;

    void Start()
    {

    }

    void Update()
    {
      
    }
    
    void OnTriggerEnter(Collider PlayerCollider)
    {
     
        if (PlayerCollider.gameObject.tag == "Obstacle")
        {
            Debug.Log("hello "+ PlayerCollider.gameObject.name);

            SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);

        }


        if (PlayerCollider.gameObject.tag == "Coin")
        {
            Debug.Log("coinsss");
            myScore.score += 100;
        }
    }
}
