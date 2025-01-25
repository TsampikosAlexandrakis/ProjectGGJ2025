using UnityEngine;

[CreateAssetMenu(fileName = "IngredientSO", menuName = "ScriptableObjects/IngredientSO", order = 1)]
public class IngredientSO : ScriptableObject
{
    public string name;
    public Sprite icon;
}
