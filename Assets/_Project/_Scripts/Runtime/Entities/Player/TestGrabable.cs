using UnityEngine;

public class TestGrabable : MonoBehaviour, IGrabable
{
    public Rigidbody rb;

    public float atractionforce;
    
    public bool isGrabbed = false;

    public bool IsGrabbed
    {
        get => isGrabbed;
        set => isGrabbed = value;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabbed)
        {
            moveObject();
        }
    }

    void moveObject()
    {
        if (Vector3.Distance(rb.transform.position, PlayerController.instance.grabPoint.position) > 0.1f)
        {
            Vector3 moveDirection = (PlayerController.instance.grabPoint.position - transform.position);

            rb.AddForce(moveDirection * atractionforce * Time.deltaTime);
        }
    }
    
    public void Grab()
    {
        rb.useGravity = false;
        rb.linearDamping = 5;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        rb.transform.parent = PlayerController.instance.grabPoint;
        isGrabbed = true;
        
    }

    public void Release()
    {
        rb.useGravity = true;
        rb.linearDamping = 1;
        rb.constraints = RigidbodyConstraints.None;

        rb.transform.parent = null;
        isGrabbed = false;
        
    }

    
}
