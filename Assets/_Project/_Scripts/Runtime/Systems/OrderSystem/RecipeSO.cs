using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeSO", menuName = "ScriptableObjects/RecipeSO", order = 1)]
public class RecipeSO : ScriptableObject
{
    //public float expirationTime;
    public string RecipeName;
    [SerializeField] private int hashID;
    
    [Header("Ingredients")] 
    public IngredientSO ingredient1;
    public IngredientSO ingredient2;
    public IngredientSO ingredient3;
    public IngredientSO ingredient4;

    GameObject bubblePrefab;

    [Header("Requirements")] 
    public IngredientSO Liquid;
    public IngredientSO Solid;
    public IngredientSO Air;
    public int GetHash() => hashID;
    public bool IsRecipe(RecipeSO pendingBubble)
    {
        if (pendingBubble.Liquid == null || pendingBubble.Air == null || pendingBubble.Solid == null) return false;
        return Liquid.IsEqual(pendingBubble.Liquid.GetHash()) && Solid.IsEqual(pendingBubble.Solid.GetHash()) && Air.IsEqual(pendingBubble.Air.GetHash());
    }

    public void ForceGenID()
    {
        hashID = GenerateHashID();
    }
    public void AddIngredient(IngredientSO ingredient)
    {
        switch ( ingredient.IngredientType)
        {
            case IngredientType.Liquid:
                Liquid = ingredient;
                break;
            case IngredientType.Solid:
                Solid = ingredient;
                break;
            case IngredientType.Air:
                Air = ingredient;
                break;
            default:
                Debug.Log("Can't add Ingredient");
                break;
        }
    }
    private void OnValidate()
    {
        if (hashID == 0)
        {
            hashID = GenerateHashID();
        }
    }

    private int GenerateHashID()
    {
        string uniqueString = $"{name}_{DateTime.Now.Ticks}";
        return ComputeHash(uniqueString);
    }

    private int ComputeHash(string input)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToInt32(hashBytes, 0);
        }
    }
}


