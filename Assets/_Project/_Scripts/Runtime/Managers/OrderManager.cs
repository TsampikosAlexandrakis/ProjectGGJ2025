using System;
using System.Collections.Generic;
using UnityEngine;


public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance;
    public OrderSetupSO OrderSetupSO;
    public List<OrderSO> pendingOrders = new List<OrderSO>();
    public OrderSO currentOrder;
    public int orderCounter = -1;
    public int score = 0;
    public Action OnOrderFailed;
    public Action OnOrderSuccess;
    public Action<OrderSO> OnNewOrder;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void Start()
    {
        Init();
    }

    public void Init()
    {
        Debug.Log("Hey");
        pendingOrders = new List<OrderSO>();
        pendingOrders.AddRange(OrderSetupSO.Orders);
        NextOrder();
    }

    public void NextOrder()
    {
        orderCounter++;
        if ( orderCounter >= pendingOrders.Count)
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
    public float timer;

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
        {
            OnOrderSuccess?.Invoke();
            score++;
        }
        else
        {
            OnOrderFailed?.Invoke();
        }
            
        NextOrder();
    }
}