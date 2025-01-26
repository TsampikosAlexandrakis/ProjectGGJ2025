using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class ObjectGrab : MonoBehaviour
{
    public InputAction interactAction;
    
    [SerializeField] private GameObject rayStart;
    [SerializeField] private float rayLength;
    [SerializeField] private LayerMask mask;
    
    public GameObject grabableObject;

    private void Start()
    {
        interactAction.Enable();
    }
    
    private void Update()
    {
        InteractionHandler();
    }

    void InteractionHandler()
    {
        Ray ray = new Ray(rayStart.transform.position, rayStart.transform.forward);
        RaycastHit hitinfo;

        if(Physics.Raycast(ray, out hitinfo, rayLength, mask))
        {
            if (hitinfo.collider.GetComponent<IGrabable>() != null)
            {
                grabableObject = hitinfo.collider.gameObject;
                Debug.Log(grabableObject.name);
                if (interactAction.WasPressedThisFrame())
                {
                    Debug.Log("grabbed");
                    
                    if (grabableObject.GetComponent<IGrabable>().IsGrabbed == true)
                    {
                        grabableObject.GetComponent<IGrabable>().IsGrabbed = false;
                        grabableObject.GetComponent<IGrabable>().Release();
                        grabableObject = null;
                        PlayerController.instance.isHolding = false;
                    }
                    if (grabableObject.GetComponent<IGrabable>().IsGrabbed == false)
                    {
                        grabableObject.GetComponent<IGrabable>().Grab();
                        grabableObject.GetComponent<IGrabable>().IsGrabbed = true;
                        PlayerController.instance.isHolding = true;
                    }
                   
                }
            }
        }
    }
}
