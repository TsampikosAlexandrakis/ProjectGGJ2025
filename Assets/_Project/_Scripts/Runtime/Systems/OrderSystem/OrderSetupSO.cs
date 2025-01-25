using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OrderMa", menuName = "ScriptableObjects/OrderSetupSO", order = 1)]
public class OrderSetupSO : ScriptableObject
{
    public List<OrderSO> Orders;
}