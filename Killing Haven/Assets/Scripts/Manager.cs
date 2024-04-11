using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Manager : MonoBehaviour
{
    private PlayerInput PlayerInput;
    public PlayerInput.OnFootActions OnFoot;

    private PlayerMotor Motor;
    private PlayerLook look;
    // Start is called before the first frame update
    void Awake()
    {
        PlayerInput = new PlayerInput();
        OnFoot = PlayerInput.OnFoot;

        Motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        OnFoot.Jump.performed += ctx => Motor.Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (UIManager.gameState == GameState.Play)
        {
            //tell the playermotor to move using the value from our movement action.
            Motor.ProcessMove(OnFoot.Movement.ReadValue<Vector2>());
        }
    }

    private void LateUpdate()
    {
        if (UIManager.gameState == GameState.Play)
        {
            look.ProcessLook(OnFoot.Look.ReadValue<Vector2>());
        }
    }
    private void OnEnable() 
    {
        OnFoot.Enable();
    }
    private void OnDisable()    
    {
        OnFoot.Disable();
    }
}
