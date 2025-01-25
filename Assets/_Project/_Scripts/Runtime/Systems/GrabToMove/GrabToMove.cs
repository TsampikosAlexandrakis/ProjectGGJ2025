using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GrabToMove : MonoBehaviour, IDragHandler
{
    private Rigidbody rb;

    public float force;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnDrag(PointerEventData eventData)
    {
       rb.AddForce(eventData.delta *force);
    }
}
