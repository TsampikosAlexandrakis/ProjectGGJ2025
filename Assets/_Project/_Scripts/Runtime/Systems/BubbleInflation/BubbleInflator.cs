using UnityEngine;

public class BubbleInflator : MonoBehaviour, IInteractable
{
    public Bubble bubble;
    public float Inflationrate;
    
    
    public void BeginInteraction()
    {
        
    }

    public void Interact()
    {
        Debug.unityLogger.Log("Inflation");
        bubble.Inflate(Inflationrate);
    }

    public void EndInteraction()
    {
        
    }
}
