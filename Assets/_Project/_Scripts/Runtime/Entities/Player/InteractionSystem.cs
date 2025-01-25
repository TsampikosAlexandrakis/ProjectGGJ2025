using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionSystem : MonoBehaviour
{
    public InputAction interactAction;
    
    [SerializeField] private GameObject rayStart;
    [SerializeField] private float rayLength;
    [SerializeField] private LayerMask mask;
    
    IInteractable interactable;
    
    private void Update()
    {
        InteractionHandler();
        
        if (interactable != null)
        {
            if (interactAction.WasPressedThisFrame())
            {
                interactable.Interact();
            }
           
        }
        
    }
    
    void InteractionHandler()
    {
        Ray ray = new Ray(rayStart.transform.position, rayStart.transform.forward);
        RaycastHit hitinfo;

        if(Physics.Raycast(ray, out hitinfo, rayLength, mask))
        {
            if (hitinfo.transform.TryGetComponent<IInteractable>(out interactable));
            {
                interactable.BeginInteraction();
            }
        }
        else
        {
            if (interactable != null)
            {
                interactable.EndInteraction();
                interactable = null;
            }

        }
    }
}
