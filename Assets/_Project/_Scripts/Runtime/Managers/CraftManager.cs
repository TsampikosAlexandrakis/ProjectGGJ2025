using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CraftManager : MonoBehaviour
{
    public static CraftManager Instance;
    public RecipeSO pendingBubble;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void CreateANewBubble()
    {
        pendingBubble = ScriptableObject.CreateInstance<RecipeSO>();
        pendingBubble.ForceGenID();
    }

    public void AddToPendingBubble(IngredientSO ingredient)
    {
        pendingBubble.AddIngredient(ingredient);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            IngredientSO[] ingredientSos = Resources.LoadAll<IngredientSO>("");
            AddToPendingBubble(ingredientSos[Random.Range(0,ingredientSos.Length)]);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            CreateANewBubble();
        }
    }
}