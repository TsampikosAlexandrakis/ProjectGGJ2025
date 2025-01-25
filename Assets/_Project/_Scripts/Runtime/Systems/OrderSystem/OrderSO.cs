using UnityEngine;

[CreateAssetMenu(fileName = "OrderSO", menuName = "ScriptableObjects/OrderSO", order = 1)]
public class OrderSO : ScriptableObject
{
    public string name;
    public RecipeOrder[] recipe;
    public GameObject bubblePrefab;
    public float expirationTime;
}

[System.Serializable]
public class RecipeOrder
{
    public RecipeSO[] recipe;
    public int amount;
}