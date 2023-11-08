using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    public List<GameObject> pathSegments = new List<GameObject>();
    public float segmentMoveSpeed = 5.0f; // Speed at which the segments move towards the player
    public int numberOfSegmentsOnScreen = 5;
    private float segmentLength;
    public int completedSegments = 0;

    private List<GameObject> activeSegments = new List<GameObject>();

    void Start()
    {
        segmentLength = pathSegments[0].transform.localScale.z;

        for (int i = 0; i < numberOfSegmentsOnScreen; i++)
        {
            SpawnSegmentAtStart();
        }
    }

    void Update()
    {
        foreach (GameObject segment in activeSegments)
        {
            segment.transform.position -= Vector3.forward * segmentMoveSpeed * Time.deltaTime;
        }

        if (activeSegments[0].transform.position.z + segmentLength < 0)
        {
            SpawnSegment();
            DeleteSegment();
        }
    }

    void SpawnSegmentAtStart()
    {
        GameObject go = Instantiate(pathSegments[Random.Range(0, pathSegments.Count)]);
        go.transform.SetParent(transform);
        
        go.transform.position = new Vector3(transform.position.x, transform.position.y, (activeSegments.Count) * segmentLength);
        activeSegments.Add(go);
        
        Debug.Log("Spawned new segment at start.");
    }

    void SpawnSegment()
    {
        GameObject go = Instantiate(pathSegments[Random.Range(0, pathSegments.Count)]);
        go.transform.SetParent(transform);
        
        
        go.transform.position = new Vector3(transform.position.x, transform.position.y, (activeSegments.Count - 1) * segmentLength);
        activeSegments.Add(go);
        
        Debug.Log("Spawned new segment.");
    }

    void DeleteSegment()
    {
        Destroy(activeSegments[0]);
        activeSegments.RemoveAt(0);
        completedSegments++; 
        
        Debug.Log($"Deleted a segment. Total completed segments: {completedSegments}");
    }
}