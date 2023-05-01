using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    private Vector2 _moveValue;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(
            _moveValue.x * speed * Time.deltaTime,
            rb.velocity.y);      
    }

    public void UpdateDirections(InputAction.CallbackContext context)
    {
        _moveValue = context.ReadValue<Vector2>();
    }
}
