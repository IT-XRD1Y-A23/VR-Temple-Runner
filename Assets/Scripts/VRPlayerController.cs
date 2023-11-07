using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRPlayerController : MonoBehaviour
{
  
    private Transform _controllerL, _controllerR, _headset, _player;
    public GameObject _objectControllerL, _objectControllerR, _objectHeadset, _objectPlayer;
    private Collider PlayerCollider;
    

    void Start()
    {
        _controllerL = _objectControllerL.GetComponent<Transform>();
        _controllerR = _objectControllerL.GetComponent<Transform>();
        _headset = _objectHeadset.GetComponent<Transform>();
        _player = _objectPlayer.GetComponent<Transform>();
    }

    void Update()
    {
      
    }

    void OnCollisionEnter(Collision collision)
    {
        
        // Handle collision with an obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Game over or damage player
            Debug.Log("Collided with obstacle!");
        }
    }
    
    void OnTriggerEnter(Collider PlayerCollider)
    {
        Debug.Log("hello "+ PlayerCollider.gameObject.name);
    }
}
