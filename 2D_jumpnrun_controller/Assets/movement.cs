using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    [SerializeField] private float speed = 0f;
    
    public bool moveVertical = true;
    private Vector2 _moveValue;

    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {

    }    

    // Update is called once per frame
    private void FixedUpdate()
    {        

        if(moveVertical)
        {
            rb.velocity = new Vector2(_moveValue.x * speed * Time.deltaTime, _moveValue.y * speed * Time.deltaTime);        // rb.velocity.y
        }
        else
            rb.velocity = new Vector2(_moveValue.x * speed * Time.deltaTime, rb.velocity.y);        

        // Debug.Log(rb.velocity);
    }

    public void UpdateDirection(InputAction.CallbackContext context)
    {
        _moveValue = context.ReadValue<Vector2>();
        // Debug.Log(_moveValue);
    }    
}
