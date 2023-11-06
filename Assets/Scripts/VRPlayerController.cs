using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRPlayerController : MonoBehaviour
{
    public float laneWidth = 2.0f; // Width of each lane
    public float laneChangeSpeed = 5.0f; // How quickly the player changes lanes
    private int currentLane = 0; // 0 is the middle lane, -1 is left, 1 is right
    private Vector3 targetPosition;

    private XRNode headNode = XRNode.Head; // Change to XRNode.CenterEye or XRNode.LeftEye/RightEye if needed

    void Start()
    {
        // Initialize the player's target position to the current position
        targetPosition = transform.position;
    }

    void Update()
    {
        // Check if an XR display subsystem is available and running
        if (IsXRRunning())
        {
            CheckForLaneChange();
        }

        // Move the player towards the target position
        MoveToTargetPosition();
    }

    bool IsXRRunning()
    {
        var xrDisplaySubsystems = new List<XRDisplaySubsystem>();
        SubsystemManager.GetInstances(xrDisplaySubsystems);
        foreach (var xrDisplay in xrDisplaySubsystems)
        {
            if (xrDisplay.running)
            {
                return true;
            }
        }
        return false;
    }

    void CheckForLaneChange()
    {
        // Get the head rotation from the InputTracking class
        Quaternion headRotation = InputTracking.GetLocalRotation(headNode);

        // Determine if the player's head is tilted enough to the left or right to initiate a lane change
        if (headRotation.eulerAngles.y > 15 && headRotation.eulerAngles.y < 45 && currentLane <= 0)
        {
            // Tilted to the right, move to the right lane
            currentLane++;
            UpdateTargetPosition();
        }
        else if (headRotation.eulerAngles.y < 345 && headRotation.eulerAngles.y > 315 && currentLane >= 0)
        {
            // Tilted to the left, move to the left lane
            currentLane--;
            UpdateTargetPosition();
        }
    }

    void UpdateTargetPosition()
    {
        // Update the target position based on the current lane
        targetPosition = new Vector3(currentLane * laneWidth, transform.position.y, transform.position.z);
    }

    void MoveToTargetPosition()
    {
        // Move towards the target position smoothly
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, laneChangeSpeed * Time.deltaTime);
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
}
