using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class FirstPersonController : GravityController
{
    public float moveSpeed, lookSpeed, jumpAmount;

    [SerializeField] Transform camTransform;

    Vector2 moveDir;

    protected override void MoveController()
    {
        base.MoveController();

        Vector3 movement = moveSpeed * moveDir.x * transform.right + moveSpeed * moveDir.y * transform.forward;

        //print("Move " + xz);

        _velocity.x = movement.x;
        _velocity.z = movement.z;
    }


    public void OnMove(InputValue val)
    {
        moveDir = val.Get<Vector2>();
    }

    public void OnLook(InputValue val)
    {
        Vector2 lookYX = lookSpeed * Time.deltaTime * val.Get<Vector2>();

        transform.Rotate(Vector3.up * lookYX.x);
        camTransform.Rotate(Vector3.left * lookYX.y);
        
    }

    public void OnJump(InputValue val)
    {
        if(controller.isGrounded) _velocity.y = jumpAmount;
    }
}
