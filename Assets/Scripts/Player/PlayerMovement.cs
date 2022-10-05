using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public float jumpForce;
    public float turnSpeed;

    private Rigidbody rb;

    private bool isJumping = false;
    private Vector3 movement = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            isJumping = true;
        }
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * speed;
        movement = transform.rotation * movement;

        transform.Rotate(0, Input.GetAxis("Mouse X") * turnSpeed, 0);
    }

	private void FixedUpdate() {
        if (isJumping) rb.AddForce(0, jumpForce, 0);
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        isJumping = false;
	}
}
