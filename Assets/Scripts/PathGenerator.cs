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
        segmentLength = GetColliderSizeZ(pathSegments[0]);

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

    float GetColliderSizeZ(GameObject obj)
    {
        Collider collider = obj.GetComponent<Collider>();
        if (collider != null)
        {
            // Assuming the collider is a box collider
            return collider.bounds.size.z;
        }

        // Return a default value if no collider is found
        return 1.0f;
    }

    void SpawnSegmentAtStart()
    {
        GameObject go = Instantiate(pathSegments[Random.Range(0, pathSegments.Count)]);
        go.transform.SetParent(transform);

        float segmentZ = (activeSegments.Count) * segmentLength;
        go.transform.position = new Vector3(transform.position.x, transform.position.y, segmentZ);
        activeSegments.Add(go);

       
    }

    void SpawnSegment()
    {
        GameObject go = Instantiate(pathSegments[Random.Range(0, pathSegments.Count)]);
        go.transform.SetParent(transform);

        float segmentZ = (activeSegments.Count - 1) * segmentLength;
        go.transform.position = new Vector3(transform.position.x, transform.position.y, segmentZ);
        activeSegments.Add(go);
    }

    void DeleteSegment()
    {
        Destroy(activeSegments[0]);
        activeSegments.RemoveAt(0);
        completedSegments++;
    }
}
