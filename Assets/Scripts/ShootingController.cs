using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ShootingController : MonoBehaviour
{
    public XRRayInteractor rayInteractor;
    [SerializeField] private InputActionReference triggerActionRef;
    public scoreObj scoreObj;
    public ScoreHandler myScoreHandler;
    public float rayRange = 10;
    public AudioSource cubeShootSound;


    public LayerMask targetLayer;

    public XRInteractorLineVisual lineVisual;
    public Gradient defaultRayGradient = new Gradient();
    public Gradient targetRayGradient = new Gradient();

    void Start()
    {
        if (lineVisual != null)
        {
            // Set the initial color of the Line Renderer
            lineVisual.invalidColorGradient = defaultRayGradient;
        }
    }

    void Update()
    {
        Ray ray = new Ray(rayInteractor.transform.position, rayInteractor.transform.forward);
        RaycastHit hit;

        float triggerValue = triggerActionRef.action.ReadValue<float>();

        // Perform the raycast with a LayerMask to filter by the target layer
        if (Physics.Raycast(ray, out hit, rayRange, targetLayer))
        {
            if(hit.collider.gameObject.CompareTag("Target"))
            {
                if (triggerValue >= 1)
                {
                    Shoot(hit);
                }
                
            }
            ChangeRayGradient(targetRayGradient);
        }
        else
        {
        ChangeRayGradient(defaultRayGradient);
        }
    }

    void Shoot(RaycastHit hit)
    {
        Destroy(hit.collider.gameObject);
        cubeShootSound.Play();
        // Revert the color after the specified delay
        myScoreHandler.HitTarget();
    }

    void ChangeRayGradient(Gradient newGradient)
    {
        if (lineVisual != null)
        {
            lineVisual.invalidColorGradient = newGradient;
        }
    }
}
