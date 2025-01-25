
using System.Collections.Generic;

using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public static RecipeManager Instance;

    public List<RecipeSO> AllRecipes;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public bool CheckRecipeExists(RecipeSO inRecipe)
    {
        bool exists = false;
        foreach (var allRecipe in AllRecipes)
        {
            exists = allRecipe.IsRecipe(inRecipe);
            if (exists)
            {
                break;
            }
        }

        return exists;
    }
}