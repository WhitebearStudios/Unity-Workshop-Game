using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class GravityController : MonoBehaviour
{
    [InspectorLabel("Positive gravity = positive y acceleration")]
    public float gravity;
    public bool grounded;

    protected CharacterController controller;

    protected Vector3 _velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveController();
    }

    protected virtual void MoveController()
    {
        if (!controller.isGrounded) _velocity.y += gravity;
        if (_velocity != Vector3.zero) controller.Move(_velocity * Time.deltaTime);
    }
}
