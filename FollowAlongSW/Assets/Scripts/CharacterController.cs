using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Rigidbody characterBody;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float rotationSpeed = 100f;

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(transform.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical"), Space.World);
        }

        if (Input.GetKeyDown(KeyCode.Space) && characterBody.velocity.y <= 0.05f)
        {
            Jump();
        }
    }

    private void Jump()
    {
        characterBody.AddForce(Vector3.up * 500f);
    }
}
