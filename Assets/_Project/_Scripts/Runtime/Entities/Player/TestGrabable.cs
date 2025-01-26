using UnityEngine;

public class TestGrabable : MonoBehaviour, IGrabable
{
    public Rigidbody rb;

    public float atractionforce;
    
    private bool isGrabbed = false;

    public bool IsGrabbed
    {
        get { return isGrabbed; }
        set { isGrabbed = value; }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrabbed)
        {
            rb.AddForce(PlayerController.instance.grabPoint.position *atractionforce, ForceMode.Impulse );
        }
        
    }

    public void Grab()
    {
        if (!isGrabbed)
        {
            IsGrabbed = true;
        }
        
    }

    public void Release()
    {
        if (isGrabbed)
        {
            IsGrabbed = false;
        }
        
    }

    
}
