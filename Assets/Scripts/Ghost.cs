using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ghost : MonoBehaviour
{
    public float MoveSpeed = 5f;

    private Vector2 moveVelocity;
    public Rigidbody2D RB;

    public InputAction GhostControls;

    private void OnEnable()
    {
        GhostControls.Enable();
    }
    private void OnDisable()
    {
        GhostControls.Disable();    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveVelocity = GhostControls.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        RB.velocity = moveVelocity.normalized * MoveSpeed;
    }

    public void MoveX(InputAction.CallbackContext context)
    {
        Debug.Log("MoveX called");
        Debug.Log(context.ReadValue<Vector2>());
        moveVelocity = new Vector2(context.ReadValue<Vector2>().x, context.ReadValue<Vector2>().y);
    }
    public void MoveY(InputAction.CallbackContext context)
    {
        Debug.Log("MoveY called");
        Debug.Log(context.ReadValue<Vector2>());
        moveVelocity = new Vector2(context.ReadValue<Vector2>().x, context.ReadValue<Vector2>().y);
    }
}