using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
   public Image orderTimerBG;
   public TMP_Text recipesText; 
   public VerticalLayoutGroup recipesLayoutGroup;
   public GameObject reqUI;
   public TMP_Text timerText;
   public void Start()
   {
       OrderManager.Instance.OnNewOrder += OnNewOrder;
   }

   private void ClearGroup()
   {
       foreach (Transform o in recipesLayoutGroup.transform)
       {
           Destroy(o.gameObject);
       }
   }

   private void SetReqUI()
   {
       
   }
   private void OnNewOrder(OrderSO obj)
   {
       ClearGroup();
       
       recipesText.text = "";
       if(obj.Bubbles.Length <= 0 ) return; 
       foreach (var bubble in obj.Bubbles)
       {
           GameObject GO = Instantiate(reqUI, recipesLayoutGroup.transform);
           GO.GetComponentInChildren<Image>().sprite = bubble.recipe.BubbleIcon;
           GO.GetComponentInChildren<TMP_Text>().text = $"x{bubble.amount}";
           //recipesText.text += $"{bubble.recipe.RecipeName} x{bubble.amount}";
       }
   }
   
   public void SetOrderTimer()
   {
      float currentTimer = OrderManager.Instance.timer;
      float orderDuration = OrderManager.Instance.currentOrder.expirationTime;
      float fill = currentTimer / orderDuration;
      orderTimerBG.fillAmount = fill;
      timerText.text = $"{Mathf.FloorToInt(currentTimer)}";
   }

   private void FixedUpdate()
   {
       SetOrderTimer();
   }
}
