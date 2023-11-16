using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float spinSpeed = 300f;

    void Start()
    {
        // Rotate the object 90 degrees around the X-axis on start
        transform.Rotate(90f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around the Z-axis
        transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
    }
}
