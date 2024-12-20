using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 3f;
    [SerializeField] private LayerMask interactionLayer;

    private Camera playerCamera;
    private Outline lastOutlinedObject; 

    void Start()
    {
        playerCamera = Camera.main;
    }

    void Update()
    {
        HandleHover();

        if (Input.GetKeyDown(KeyCode.E))
        {
            PerformInteraction();
        }
    }

    private void PerformInteraction()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance, interactionLayer))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }

    private void HandleHover()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance, interactionLayer))
        {
            Outline outline = hit.collider.GetComponent<Outline>();
            if (outline != null)
            {
                if (outline != lastOutlinedObject) 
                {
                    if (lastOutlinedObject != null)
                    {
                        lastOutlinedObject.enabled = false; 
                    }
                    outline.enabled = true;
                    lastOutlinedObject = outline;
                }
            }
            else if (lastOutlinedObject != null) 
            {
                lastOutlinedObject.enabled = false;
                lastOutlinedObject = null;
            }
        }
        else if (lastOutlinedObject != null) 
        {
            lastOutlinedObject.enabled = false;
            lastOutlinedObject = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * interactionDistance);
    }
}
