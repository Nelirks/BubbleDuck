using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

//Code from https://sharpcoderblog.com/blog/third-person-camera-in-unity-3d
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 7.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Transform cameraParent;
    public Transform characterModel;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;
    float characterRotationSpeed = 120;

    [HideInInspector]
    public bool canMove = true;

    void Awake() {
        characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        rotation.y = transform.eulerAngles.y;
    }

	public void OnDisable() {
        rb.constraints = RigidbodyConstraints.FreezeAll;
	}

	private void OnEnable() {
        rb.constraints = RigidbodyConstraints.None;
    }

    void Update() {
        if (characterController.isGrounded) {
            // We are grounded, so recalculate move direction based on axes
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            float curSpeedX = canMove ? speed * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            if (Input.GetButton("Jump") && canMove) {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y = moveDirection.y - gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove) {
            rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
            rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
            cameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);
            transform.eulerAngles = new Vector2(0, rotation.y);
            RotateCharacterModel();
        }
    }

    private void RotateCharacterModel() {
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) return;
        float currentAngle = characterModel.localEulerAngles.y;
        float targetAngle = -Vector2.SignedAngle(Vector2.left, new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"))) + 180;
        if (Mathf.Abs(targetAngle - currentAngle) < 1f) return;
        else if (targetAngle > currentAngle && targetAngle - currentAngle < 178 || targetAngle < currentAngle && currentAngle - targetAngle > 178) 
            characterModel.Rotate(new Vector3(0, 0, characterRotationSpeed * Time.deltaTime));
        else characterModel.Rotate(new Vector3(0, 0, -characterRotationSpeed * Time.deltaTime));
    }

    public void TeleportTo(Vector3 position) {
        transform.position = position;
        moveDirection = Vector3.zero;
    }
}
