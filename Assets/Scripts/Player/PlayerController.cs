using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private CharacterController controller;
    
    [SerializeField]
    private float playerSpeed = 1.0f;

    private void Awake()
    {
        playerInput = new PlayerInput();
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Start()
    {
        GameEvents.instance.onSpeedUp += SpeedUp;
    }

    private void SpeedUp()
    {
        playerSpeed += 1f;
    }

    void Update()
    {
        Vector2 movement = playerInput.PlayerMap.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);

        controller.Move(move * Time.deltaTime * playerSpeed);
    }
}
