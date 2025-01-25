using UnityEngine;

[CreateAssetMenu(fileName = "RecipeSO", menuName = "ScriptableObjects/RecipeSO", order = 1)]
public class RecipeSO : ScriptableObject
{
    public float expirationTime;
    
    [Header("Ingredients")]
    public IngredientSO ingredient1;
    public IngredientSO ingredient2;
    public IngredientSO ingredient3;
    public IngredientSO ingredient4;
    
    GameObject bubblePrefab;
    
}
