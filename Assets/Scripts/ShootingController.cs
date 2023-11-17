using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;


public class ShootingController : MonoBehaviour
{
    public XRRayInteractor rayInteractor;
    [SerializeField] private InputActionReference triggerActionRef;
    public scoreObj scoreObj;

    public LayerMask targetLayer;

    void Start()
    {

    }

    void Update()
    {

        float triggerValue = triggerActionRef.action.ReadValue<float>();
        if (triggerValue >= 1)
        {
            // Trigger the custom logic when the trigger is pressed
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = new Ray(rayInteractor.transform.position, rayInteractor.transform.forward);
        RaycastHit hit;

        // Perform the raycast with a LayerMask to filter by the target layer
        if (Physics.Raycast(ray, out hit, 1000f, targetLayer))
        {
            // Check if the hit GameObject has the specified tag
            if (hit.collider.gameObject.CompareTag("Target"))
            {
                Destroy(hit.collider.gameObject);
                scoreObj.score += 100;
                Debug.Log("Target hit +100");
            }
        }
    }
}
