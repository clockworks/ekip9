using System;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    private Rigidbody _rigidbody;


    private void Awake()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movementDirection = new Vector3(horizontalInput, 0f, 0);
        movementDirection.Normalize();

        Vector3 newPosition = _rigidbody.transform.position + transform.forward * movementSpeed * Time.deltaTime;
        _rigidbody.MovePosition(newPosition);
        // transform.position += newPosition;
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}