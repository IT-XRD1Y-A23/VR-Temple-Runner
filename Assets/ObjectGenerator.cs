using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject cubePrefab; // Drag your cube prefab to this field in the Unity editor
    public int numberOfCubes = 10; // Adjust the number of cubes as needed

    void Start()
    {
        GenerateCubesOnTop();
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
            GameObject cube = Instantiate(cubePrefab, cubePosition, Quaternion.identity);

            // Make the cube a child of the shape
            cube.transform.parent = transform;
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
