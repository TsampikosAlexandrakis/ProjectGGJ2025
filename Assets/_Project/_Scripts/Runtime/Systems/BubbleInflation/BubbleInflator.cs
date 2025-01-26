using System;
using UnityEngine;
using UnityEngine.UI;

public class BubbleInflator : MonoBehaviour, IInteractable
{
    public Bubble bubble;
    public float Inflationrate;
    
    public Image progressBar;

    
    
    public void Start()
    {
        bubble.bubbleRecipe = CraftManager.Instance.pendingBubble;
    }

    public void BeginInteraction()
    {
        
    }

    public void Interact()
    {
        Debug.Log("Inflation");
        bubble.Inflate(Inflationrate);
    }

    public void EndInteraction()
    {
        
    }

    private void Update()
    {
        if (bubble != null)
        {
            progressBar.fillAmount = (bubble.size/bubble.maxSize) /100f * Time.deltaTime;
        }

        if (bubble != null)
        {
            Instantiate(bubble.bubbleRecipe, transform.position, transform.rotation);
        }

        if (bubble == null)
        {
            progressBar.fillAmount = 0;
           
        }
    }
}
