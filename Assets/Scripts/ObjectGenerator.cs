using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject cubePrefab;
    public int numberOfCubes = 3;
    public float platformWidth = 2;

    void Start()
    {
        GeneratePlatform();
    }

    void GeneratePlatform()
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            float xPosition = Random.Range(-platformWidth / 3, platformWidth / 3);
            Vector3 spawnPosition = new Vector3(xPosition, 0f, i * 1f); // Adjust the '2f' to control the gap between cubes

            Instantiate(cubePrefab, spawnPosition, Quaternion.identity, transform);
        }
    }
    
}
