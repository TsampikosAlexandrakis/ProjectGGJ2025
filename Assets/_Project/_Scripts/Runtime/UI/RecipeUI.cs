using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeUI : MonoBehaviour,  IInteractable
{
    public TMP_Text RecipeName;
    public Image BubbleIcon;
    public VerticalLayoutGroup recipesLayoutGroup;
    public GameObject reqUI;
    private int recipeCounter = -1;
    
    public void SetRecipe()
    {
        ClearGroup();
        recipeCounter++;
        if (recipeCounter >= RecipeManager.Instance.AllRecipes.Count)
        {
            recipeCounter = 0;
        }
        RecipeSO recipe = RecipeManager.Instance.AllRecipes[recipeCounter];
        RecipeName.text = recipe.RecipeName;
        BubbleIcon.sprite = recipe.BubbleIcon;
        var GoL = Instantiate(reqUI, recipesLayoutGroup.transform);
        GoL.GetComponentsInChildren<Image>()[0].enabled = false;
        GoL.GetComponentsInChildren<Image>()[1].sprite = recipe.Liquid.IngredientIcon; 
        GoL.GetComponentInChildren<TMP_Text>().text = $"";
        var GoA = Instantiate(reqUI, recipesLayoutGroup.transform);
        GoA.GetComponentsInChildren<Image>()[0].enabled = false;
        GoA.GetComponentsInChildren<Image>()[1].sprite = recipe.Air.IngredientIcon; 
        GoA.GetComponentInChildren<TMP_Text>().text = $"";
        var GoS = Instantiate(reqUI, recipesLayoutGroup.transform);
        GoS.GetComponentsInChildren<Image>()[0].enabled = false;
        GoS.GetComponentsInChildren<Image>()[1].sprite = recipe.Solid.IngredientIcon; 
        GoS.GetComponentInChildren<TMP_Text>().text = $"";
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Todo
            SetRecipe();
        }
    }
  
    private void ClearGroup()
    {
        foreach (Transform o in recipesLayoutGroup.transform)
        {
            Destroy(o.gameObject);
        }
    }


    public void BeginInteraction()
    {
    }

    public void Interact()
    {
        SetRecipe();
    }

    public void EndInteraction()
    {
    }
}