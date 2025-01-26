using UnityEngine;
using UnityEngine.InputSystem;
public class ObjectGrab : MonoBehaviour
{
    public InputAction interactAction;
    
    [SerializeField] private GameObject rayStart;
    [SerializeField] private float rayLength;
    [SerializeField] private LayerMask mask;
    
    public GameObject grabableObject;
    
    void InteractionHandler()
    {
        Ray ray = new Ray(rayStart.transform.position, rayStart.transform.forward);
        RaycastHit hitinfo;

        if(Physics.Raycast(ray, out hitinfo, rayLength, mask))
        {
            if (hitinfo.collider.GetComponent<IGrabable>() != null)
            {
                grabableObject = hitinfo.collider.gameObject;
                if (interactAction.IsPressed())
                {

                    if (grabableObject.gameObject.GetComponent<IGrabable>().IsGrabbed == false)
                    {
                        grabableObject.GetComponent<IGrabable>().Grab();
                    }
                    else
                    {
                        grabableObject.GetComponent<IGrabable>().Release();
                    }
                }
            }
        }
    }
}
