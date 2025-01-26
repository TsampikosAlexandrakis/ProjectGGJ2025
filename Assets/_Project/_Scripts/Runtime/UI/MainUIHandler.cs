using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
   public Image orderTimerBG;
   public TMP_Text recipesText; 
   public void Start()
   {
       OrderManager.Instance.OnNewOrder += OnNewOrder;
   }

   private void OnNewOrder(OrderSO obj)
   {
       recipesText.text = "";
       if(obj.Bubbles.Length <= 0 ) return; 
       foreach (var bubble in obj.Bubbles)
       {
           recipesText.text += $"{bubble.recipe.RecipeName} x{bubble.amount}";
       }
   }
   
   public void SetOrderTimer()
   {
      float currentTimer = OrderManager.Instance.timer;
      float orderDuration = OrderManager.Instance.currentOrder.expirationTime;
      float fill = currentTimer / orderDuration;
      orderTimerBG.fillAmount = fill;
   }

   private void FixedUpdate()
   {
       SetOrderTimer();
   }
}
