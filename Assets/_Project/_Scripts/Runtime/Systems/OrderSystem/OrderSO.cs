using UnityEngine;

[CreateAssetMenu(fileName = "OrderSO", menuName = "ScriptableObjects/OrderSO", order = 1)]
public class OrderSO : ScriptableObject
{
    public string name;
    public RecipeSO recipe;
    public GameObject bubblePrefab;
    public float expirationTime;
}
