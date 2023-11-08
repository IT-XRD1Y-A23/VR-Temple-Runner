using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject cubePrefab1, cubePrefab2, cubePrefab3; // Drag your cube prefab to this field in the Unity editor
    public int numberOfCubes = 10; // Adjust the number of cubes as needed

    void Start()
    {
        //GenerateCubesOnTop();

        GenerateCubesWithinBounds();
    }

    void Update()
    {
        // You can add code here to move or transform your shape as needed
        // For example, you might have code to move the shape based on player input.

        // Destroy existing cubes and generate new ones
       // DestroyExistingCubes();
      // GenerateCubesOnTop();
    }

    void GenerateCubesOnTop()
    {
        // Assuming your shape is a GameObject with a collider
        Collider shapeCollider = GetComponent<Collider>();

        if (shapeCollider == null)
        {
            Debug.LogError("Shape must have a collider for cube generation to work.");
            return;
        }

        // Get the bounds of the shape
        Bounds shapeBounds = shapeCollider.bounds;

        for (int i = 0; i < numberOfCubes; i++)
        {
            // Randomly generate positions within the bounds of the shape
            float randomX = Random.Range(shapeBounds.min.x+ (float)0.15, shapeBounds.max.x- (float)0.15);
           
            float randomZ = Random.Range(shapeBounds.min.z, shapeBounds.max.z);

            // Ensure that the Y position is above the shape (you can adjust the Y value accordingly)
            System.Random random = new System.Random();
            int randomValue = random.Next(1, 3);
            float heightValue=1f;
            switch (randomValue)
            {
                case 1:
                    heightValue = 1f;
                    break;
                    case 2:
                    heightValue = 1.25f;
                    break;
            }
            float yPos = shapeBounds.max.y + heightValue;

            // Create a cube at the randomly generated position
            Vector3 cubePosition = new Vector3(randomX, yPos, randomZ);

            int randomValueCube = random.Next(1, 4);
            switch (randomValueCube)
            {
                case 1:
                    GameObject cube1 = Instantiate(cubePrefab1, cubePosition, Quaternion.identity);
                    cube1.transform.parent = transform;
                    break;
                case 2:
                    GameObject cube2 = Instantiate(cubePrefab2, cubePosition, Quaternion.identity);
                    cube2.transform.parent = transform;
                    break;
                case 3:
                    GameObject cube3 = Instantiate(cubePrefab3, cubePosition, Quaternion.identity);
                    cube3.transform.parent = transform;
                    break;
            }
            // GameObject cube = Instantiate(cubePrefab1, cubePosition, Quaternion.identity);

            // Make the cube a child of the shape
            //cube.transform.parent = transform;
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
    
    void GenerateCubesWithinBounds()
    {
        // Assuming your shape is a GameObject with a collider
        Collider shapeCollider = GetComponent<Collider>();

        if (shapeCollider == null)
        {
            Debug.LogError("Shape must have a collider for cube generation to work.");
            return;
        }

        // Get the bounds of the shape
        Bounds shapeBounds = shapeCollider.bounds;

        for (int i = 0; i < numberOfCubes; i++)
        {
            // Randomly generate positions within the bounds of the shape
            float randomX = Random.Range(shapeBounds.min.x + (float)0.15, shapeBounds.max.x - (float)0.15);
            float randomY = Random.Range(shapeBounds.min.y + (float)0.15, shapeBounds.max.y - (float)0.15);
            float randomZ = Random.Range(shapeBounds.min.z + (float)0.15, shapeBounds.max.z - (float)0.15);

            // Create a cube at the randomly generated position within the bounds
            Vector3 cubePosition = new Vector3(randomX, randomY, randomZ);

            System.Random random = new System.Random();
            int randomValueCube = random.Next(1, 4);
            switch (randomValueCube)
            {
                case 1:
                    GameObject cube1 = Instantiate(cubePrefab1, cubePosition, Quaternion.identity);
                    cube1.transform.parent = transform;
                    break;
                case 2:
                    GameObject cube2 = Instantiate(cubePrefab2, cubePosition, Quaternion.identity);
                    cube2.transform.parent = transform;
                    break;
                case 3:
                    GameObject cube3 = Instantiate(cubePrefab3, cubePosition, Quaternion.identity);
                    cube3.transform.parent = transform;
                    break;
            }
        }
    }
}
