using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction _moveAction;
    public InputAction _lookAction;
    public Transform _cameraTransform;
    public float speed;
    public float cameraSensitivity;
    
    public CharacterController _characterController;
    
    private float xRotation;
    private float yRotation;
    
    private Vector3 _moveVector;
    private Vector3 _lookVector;
    
    public static PlayerController instance;
    
    public Transform grabPoint;

    public bool isHolding;

    public enum PlayerState
    {
        walking,
        cooking
    }
    
    public PlayerState state;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        _characterController = GetComponent<CharacterController>();
        _moveAction.Enable();
        _lookAction.Enable();

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case PlayerState.walking:
                MovementHandler();
                MouseHandler();
                break;
            case PlayerState.cooking:
                break;
            default:
                break;
        }
    }

    private void MovementHandler()
    {
        _moveVector = _moveAction.ReadValue<Vector3>().normalized;
        _lookVector = _lookAction.ReadValue<Vector2>();
        
        _moveVector = transform.forward * _moveVector.z + transform.right * _moveVector.x;
        
        _characterController.Move(_moveVector * speed * Time.deltaTime);
        _characterController.Move(Vector3.down * 400f * Time.deltaTime); 
    }
    
    private void MouseHandler()
    {
        yRotation += _lookVector.x * cameraSensitivity *  0.01f;
        xRotation -= _lookVector.y * cameraSensitivity *  0.01f;

        xRotation = Mathf.Clamp(xRotation, -70f, 70f);

        _cameraTransform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
