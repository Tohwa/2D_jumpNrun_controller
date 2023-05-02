using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class jumping : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rayLength;

    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private bool grounded;
    // [SerializeField] private int jumpCounter = 2;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private float bufferTime = 0.2f;
    private float bufferTimeCounter;

    private void Update()
    {
        
        grounded = CheckGrounded();
        Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.black);
        
        
        if (grounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        

    }
    
    private bool CheckGrounded()
    {
        var hitInfo = Physics2D.Raycast(
                        transform.position,
                        Vector2.down,
                        rayLength,
                        groundLayers);

        return hitInfo.collider;
    }
    
    
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            bufferTimeCounter = bufferTime;
        }
        else
        {
            bufferTimeCounter -= Time.deltaTime;
        }

        if(coyoteTimeCounter > 0f && bufferTimeCounter > 0f)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            bufferTimeCounter = 0f;
        }
        // Debug.Log(context);
    }
    
}
