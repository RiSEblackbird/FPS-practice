using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float power = 100;
    [SerializeField] private InputActionReference moveAction;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        if (moveAction != null && moveAction.action != null)
        {
            moveAction.action.Enable();
        }
    }

    private void OnDisable()
    {
        if (moveAction != null && moveAction.action != null)
        {
            moveAction.action.Disable();
        }
    }

    private void FixedUpdate()
    {
        if (moveAction == null || moveAction.action == null)
        {
            return;
        }

        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();
        Vector3 vec = new Vector3(moveInput.x, 0, moveInput.y) * speed;
        _rigidbody.AddForce(vec);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            ContactPoint contact = collision.contacts[0];
            _rigidbody.AddForce(contact.normal * power);
        }
    }
}
