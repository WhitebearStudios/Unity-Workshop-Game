using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class GravityController : MonoBehaviour
{
    [InspectorLabel("Positive gravity = positive y acceleration")]
    public float gravity;
    public bool grounded;

    CharacterController controller;

    Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!grounded)
        {
            velocity.y += gravity;

            controller.Move(velocity * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
        velocity = Vector3.zero;
    }
    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
}
