using UnityEngine;

[CreateAssetMenu(fileName = "OrderSO", menuName = "ScriptableObjects/OrderSO", order = 1)]
public class OrderSO : ScriptableObject
{
    public string name;
    public RecipeOrder[] Bubbles;
    public float expirationTime;
    
    [Header("Settings")]
    public string Name;
    public float ScoreMult;
    public float Coins;
    
}

[System.Serializable]
public class RecipeOrder
{
    public RecipeSO recipe;
    public int amount;
}