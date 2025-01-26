using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionSystem : MonoBehaviour
{
    public InputAction interactAction;
    
    [SerializeField] private GameObject rayStart;
    [SerializeField] private float rayLength;
    [SerializeField] private LayerMask mask;
    
    GameObject interactable;

    private void Awake()
    {
        interactAction.Enable();
    }

    private void Update()
    {
        if (!PlayerController.instance.isHolding)
        {
            InteractionHandler();
        }
        
        
    }
    
    void InteractionHandler()
    {
        Ray ray = new Ray(rayStart.transform.position, rayStart.transform.forward);
        RaycastHit hitinfo;

        if(Physics.Raycast(ray, out hitinfo, rayLength, mask))
        {
            if (hitinfo.collider.GetComponent<IInteractable>() != null)
            {
                interactable = hitinfo.collider.gameObject;
                
                interactable.GetComponent<IInteractable>().BeginInteraction();
                if (interactAction.IsPressed())
                {
                    
                    interactable.GetComponent<IInteractable>().Interact();
                }
            }
        }
        else
        {
            if (!interactable) return;
            if ( interactable.GetComponent<IInteractable>() != null)
            {
                interactable.GetComponent<IInteractable>().EndInteraction();
               
            }
            interactable = null;    

        }
    }
}
