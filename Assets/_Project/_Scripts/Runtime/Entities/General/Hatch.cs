
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hatch : MonoBehaviour
{
    
    public Dictionary<RecipeSO, int> BubblesContained;
    private void OnTriggerStay(Collider other)
    {
        
    }

    public void SendHatch()
    {
        OrderManager.Instance.SendHatch(BubblesContained);
    }
    private void OnTriggerEnter(Collider other)
    {
        Bubble bubble = other.GetComponent<Bubble>();
        if (!bubble) return;
        if (BubblesContained.ContainsKey(bubble.bubbleRecipe))
        {
            BubblesContained[bubble.bubbleRecipe]++;
        }
        else
        {
            BubblesContained.Add(bubble.bubbleRecipe,1);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        Bubble bubble = other.GetComponent<Bubble>();
        if (!bubble) return;
        if (BubblesContained.ContainsKey(bubble.bubbleRecipe))
        {
            BubblesContained[bubble.bubbleRecipe]--;
            if (BubblesContained[bubble.bubbleRecipe] <= 0)
            {
                BubblesContained.Remove(bubble.bubbleRecipe);
            } 
        }
      
    }
    
}