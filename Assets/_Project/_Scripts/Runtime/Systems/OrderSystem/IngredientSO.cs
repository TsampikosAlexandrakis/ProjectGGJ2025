using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "IngredientSO", menuName = "ScriptableObjects/IngredientSO", order = 1)]
public class IngredientSO : ScriptableObject
{
    
    [SerializeField] private int hashID;
    public string Name;
    public Sprite IngredientIcon;
   
    public int GetHash() => hashID;
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

    public bool IsEqual(int inHashID)
    {
        return this.hashID == inHashID;
    }
}

public enum IngredientType
{
    Liquid,
    Solid,
    Air
}
 