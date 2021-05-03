using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Controls inputs;

    Vector2 inputVector;

    public float speed;

    Rigidbody2D rb;

    public bool canRun;
    public float runMultiplicator = 2f;

    bool isRunning;

    public static event Action onTryInteract;
    public Animator animator;

   

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        inputs = new Controls();

        inputs.Gameplay.Movement.performed += ctx => inputVector = ctx.ReadValue<Vector2>();
        inputs.Gameplay.Movement.canceled += ctx => inputVector = Vector2.zero;

        inputs.Gameplay.Run.performed += _ => isRunning = canRun;
        inputs.Gameplay.Run.canceled += _ => isRunning = false;

        inputs.Gameplay.Interaction.performed += _ => onTryInteract?.Invoke();


        
        
    }

    private void OnEnable()
    {
        inputs.Gameplay.Enable();
    }


    private void FixedUpdate()
    {
        float tempMultiplicator = isRunning ? runMultiplicator : 1f;
        if (inputVector != Vector2.zero && !HideBehavior.HIDE_STATUS)
        {
            Vector3 move = inputVector * speed * tempMultiplicator * Time.fixedDeltaTime;
            rb.MovePosition(transform.position + move);
            animator.SetFloat("horizontal", move.x);
            animator.SetFloat("Vertical", move.y);
            animator.SetFloat("speed", move.magnitude);
        }
    }

    private void OnDisable()
    {
        inputs.Gameplay.Disable();
    }
}
