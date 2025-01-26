using System;
using UnityEngine;
using UnityEngine.UI;

public class Stiring : MonoBehaviour,IInteractable
{
    public float stirRate    ;
    public float SecondsToFinish;
    public float progress;

    public Image ProgressBar;
    
    public GameObject ladle;
    
    public IngredientSO currentIngredient;

    public void OnColliEnter(Collider other)
    {
        if (other.tag == "ingredient")
        {
            currentIngredient = other.GetComponent<IngredientSO>();
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ingredient")
        {
            currentIngredient = other.gameObject.GetComponent<TestGrabable>().ingredient;
            other.gameObject.SetActive(false);
            PlayerController.instance.isHolding =false;
        }
    }

    public void BeginInteraction()
    {
        
    }

    public void Interact()
    {
        if (CraftManager.Instance.pendingBubble == null)
        {
            CraftManager.Instance.CreateANewBubble();
        }
        
        
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

    private void Update()
    {
        ProgressBar.fillAmount = progress/SecondsToFinish;
    }

    public void Finished()
    {
        CraftManager.Instance.AddToPendingBubble(currentIngredient);
        progress = 0;
    }
    
    public void EndInteraction()
    {
        
    }
}
