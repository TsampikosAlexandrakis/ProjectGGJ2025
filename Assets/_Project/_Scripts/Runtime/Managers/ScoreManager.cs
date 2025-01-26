using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [Header("UI Settings")]
    public TMP_Text scoreText;

    [Header("Score Settings")]
    public int baseScorePerEvent = 10;

    OrderSO OrderMultiplier;

    private int currentScore = 0;

    [System.Serializable]
    public class ScoreEvent
    {
        public string eventName;
        public bool triggerEvent;
    }

    [Header("Event Settings")]
    public ScoreEvent eventTrigger;

    private void Update()
    {
       
        if (eventTrigger.triggerEvent)
        {
            AddScore(baseScorePerEvent);
            eventTrigger.triggerEvent = false;
        }
    }

    private void AddScore(int basePoints)
    {

        float totalPoints = basePoints * (OrderMultiplier.ScoreMult) ;
        currentScore += Mathf.RoundToInt(totalPoints);
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore;
        }
    }
}
