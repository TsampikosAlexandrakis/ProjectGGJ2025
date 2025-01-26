using System;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public static Crosshair instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ToggleInteractUI(bool show)
    {
        canvasGroup.alpha = show ? 1 : 0;
    }
}
