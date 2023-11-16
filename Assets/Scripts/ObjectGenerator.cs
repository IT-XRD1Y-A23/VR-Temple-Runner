using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject cubePrefab1, cubePrefab2, cubePrefab3, coin, target; // Drag your cube prefab to this field in the Unity editor
    public int baseNumberOfCubes = 10;
    public int baseNumberOfCoins = 2;
    public int baseNumberOfTargets = 2;
    public PathGenerator pathGenerator;
    void Start()
    {
        GenerateCubesWithinBounds();
        GenerateCoinsWithinBounds();
        GenerateTargetsWithinBounds();
    }

 

    void GenerateCubesWithinBounds()
    {
        if (pathGenerator == null)
        {
            Debug.LogError("PathGenerator reference not set on CubeGenerator script.");
            return;
        }

        // Assuming your shape is a GameObject with a collider
        Collider shapeCollider = GetComponent<Collider>();

        if (shapeCollider == null)
        {
            Debug.LogError("Shape must have a collider for cube generation to work.");
            return;
        }

        // Get the bounds of the shape
        Bounds shapeBounds = shapeCollider.bounds;

        // Adjust the number of cubes based on the number of completed segments
        int cubesToGenerate = baseNumberOfCubes + (pathGenerator.completedSegments); // Example of difficulty curve

   
        
        for (int i = 0; i < cubesToGenerate; i++)
        {
            float randomX = Random.Range(shapeBounds.min.x + 0.15f, shapeBounds.max.x - 0.15f);
            float randomY = Random.Range(shapeBounds.min.y + 0.15f, shapeBounds.max.y - 0.15f);
            float randomZ = Random.Range(shapeBounds.min.z + 0.15f, shapeBounds.max.z - 0.15f);

            Vector3 cubePosition = new Vector3(randomX, randomY, randomZ);
            GameObject cubePrefab = ChooseRandomCubePrefab();

            if (cubePrefab != null)
            {
                GameObject cube = Instantiate(cubePrefab, cubePosition, Quaternion.identity);
                cube.transform.parent = transform;
            }
        }
    }

    void GenerateCoinsWithinBounds()
    {
        if (pathGenerator == null)
        {
            Debug.LogError("PathGenerator reference not set on CubeGenerator script.");
            return;
        }

        // Assuming your shape is a GameObject with a collider
        Collider shapeCollider = GetComponent<Collider>();

        if (shapeCollider == null)
        {
            Debug.LogError("Shape must have a collider for cube generation to work.");
            return;
        }

        // Get the bounds of the shape
        Bounds shapeBounds = shapeCollider.bounds;

        // Adjust the number of cubes based on the number of completed segments
        int coinsToGenerate = baseNumberOfCoins + (pathGenerator.completedSegments); // Example of difficulty curve



        for (int i = 0; i < coinsToGenerate; i++)
        {
            float randomX = Random.Range(shapeBounds.min.x + 0.15f, shapeBounds.max.x - 0.15f);
            float randomY = Random.Range(shapeBounds.min.y + 0.15f, shapeBounds.max.y - 0.15f);
            float randomZ = Random.Range(shapeBounds.min.z + 0.15f, shapeBounds.max.z - 0.15f);

            Vector3 coinPosition = new Vector3(randomX, randomY, randomZ);
            GameObject coinPrefab = coin;
            if (coin != null)
            {
                GameObject coin = Instantiate(coinPrefab, coinPosition, Quaternion.identity);
                coin.transform.parent = transform;
            }
        }
    }

    void GenerateTargetsWithinBounds()
    {
        if (pathGenerator == null)
        {
            Debug.LogError("PathGenerator reference not set on CubeGenerator script.");
            return;
        }

        // Assuming your shape is a GameObject with a collider
        Collider shapeCollider = GetComponent<Collider>();

        if (shapeCollider == null)
        {
            Debug.LogError("Shape must have a collider for cube generation to work.");
            return;
        }

        // Get the bounds of the shape
        Bounds shapeBounds = shapeCollider.bounds;

        // Adjust the number of cubes based on the number of completed segments
        int targetsToGenerate = baseNumberOfTargets + (pathGenerator.completedSegments); // Example of difficulty curve



        for (int i = 0; i < targetsToGenerate; i++)
        {
            float randomX = Random.Range(shapeBounds.min.x + 0.15f, shapeBounds.max.x - 0.15f);
            float randomY = Random.Range(shapeBounds.min.y + 0.15f, shapeBounds.max.y - 0.15f);
            float randomZ = Random.Range(shapeBounds.min.z + 0.15f, shapeBounds.max.z - 0.15f);

            Vector3 targetPosition = new Vector3(randomX, randomY, randomZ);
            GameObject targetPrefab = target;
            if (target != null)
            {
                GameObject target = Instantiate(targetPrefab, targetPosition, Quaternion.identity);
                target.transform.parent = transform;
            }
        }
    }
    GameObject ChooseRandomCubePrefab()
    {
        int randomValueCube = Random.Range(1, 4);
        switch (randomValueCube)
        {
            case 1:
                return cubePrefab1;
            case 2:
                return cubePrefab2;
            case 3:
                return cubePrefab3;
            default:
                return null;
        }
    }
    
    void DestroyExistingCubes()
    {
        // Destroy all existing child cubes
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        
        
    }
}
