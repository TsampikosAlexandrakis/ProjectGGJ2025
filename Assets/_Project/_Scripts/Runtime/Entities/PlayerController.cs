using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction _moveAction;
    
    public float speed;
    
    public CharacterController _characterController;
    
    private Vector3 _moveVector;
    
    
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _moveAction.Enable();

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _moveVector = _moveAction.ReadValue<Vector3>().normalized;
        Debug.Log(_moveVector);
        _moveVector = transform.TransformDirection(_moveVector);
        _characterController.SimpleMove(_moveVector * speed * Time.deltaTime);
    }
}
