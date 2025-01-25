using System;
using System.Collections.Generic;
using UnityEngine;


public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance;
    public OrderSetupSO OrderSetupSO;
    private List<OrderSO> pendingOrders;
    public OrderSO currentOrder;
    public int orderCounter = 0;
    public int score = 0;
    public Action OnOrderFailed;
    public Action OnOrderSuccess;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void Init()
    {
        pendingOrders = OrderSetupSO.Orders;
    }

    public void NextOrder()
    {
        orderCounter++;
        if (pendingOrders.Count >= orderCounter)
        {
            NoOrders();
            return;
        }

        if (pendingOrders[orderCounter] == null)
        {
            NoOrders();
        }

        SetNewOrder(pendingOrders[orderCounter]);
    }

    public void NoOrders()
    {
        // TODO:: Finish level, drop Score screen
        Debug.Log("No more orders, finishing level");
    }

    public void SetNewOrder(OrderSO order)
    {
        isRunning = true;
        currentOrder = order;
        timer = currentOrder.expirationTime;
    }

    private bool isRunning;
    private float timer;

    private void Update()
    {
        if (isRunning)
        {
            timer -= Time.deltaTime;
            Debug.Log(timer);
            if (timer <= 0)
            {
                isRunning = false;
                FinishOrder(false);
            }
        }
    }

    public void FinishOrder(bool successful)
    {
        isRunning = false;
        if (successful)
            score++;
        NextOrder();
    }
}