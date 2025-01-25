using UnityEngine;

public class Stiring : MonoBehaviour,IInteractable
{
    public float stirRate    ;
    public float SecondsToFinish;
    public float progress;

    public GameObject ladle;
    
    public void BeginInteraction()
    {
        
    }

    public void Interact()
    {
        
        
        if (progress < SecondsToFinish)
        {
            progress += stirRate * Time.deltaTime;
            float rotationR = 360.0f * progress;
            ladle.transform.localEulerAngles = new Vector3(0, 0, rotationR) ;    
        }

        if (progress >= SecondsToFinish)
        {
            Finished();
        }
        
    }

    public void Finished()
    {
        Debug.Log("Finished");
    }
    
    public void EndInteraction()
    {
        
    }
}
