using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject mainCamera;
    public Vector2 mouseRotation;
    public Vector2 movement;
    private Rigidbody rb;

    [Range(0, 100)]public float moveSpeed;
    [Range(0, 10)]public float moveSpeedMultiplier;
    [Range(0, 1)]public float lookSpeed;
    public float jumpForce;
    public float lookAngleMax;
    public float lookAngleMin;

    float rotY = 0;

    public Transform groundCheck;
    public bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        //Movement
        Movement();

        //Camera Control
        CameraControl();

        //Jump
        /*isGrounded = CheckGround();*/
        Jump();

        GravityControl();

    }

    private void GravityControl()
    {

    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Vector3 jumpDirection = Vector3.up * jumpForce;
            rb.AddForce(jumpDirection, ForceMode.Impulse);
        }
    }

    /*private bool CheckGround()
    {
        RaycastHit hit;

        float distance = Vector3.Distance(transform.position, groundCheck.position);

        hit = Physics.Raycast

    }*/

    private void CameraControl()
    {
        transform.Rotate(Vector3.up, mouseRotation.x * lookSpeed);

        mainCamera.transform.Rotate(-mouseRotation.y * lookSpeed, 0, 0);

        mainCamera.transform.localRotation = Quaternion.Euler(lookAngleMin, mainCamera.transform.localEulerAngles.y, mainCamera.transform.localEulerAngles.z);

        rotY += mouseRotation.y * lookSpeed;

        rotY = Mathf.Clamp(rotY, lookAngleMin, lookAngleMax);

        mainCamera.transform.rotation = Quaternion.Euler(-rotY, mainCamera.transform.eulerAngles.y, mainCamera.transform.eulerAngles.z);
    }

    private void Movement()
    {
        mouseRotation = Input.mousePositionDelta;

        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 moveVelocity;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveVelocity = (transform.forward * movement.y + transform.right * movement.x) * moveSpeed * moveSpeedMultiplier;
        }
        else
        {
            moveVelocity = (transform.forward * movement.y + transform.right * movement.x) * moveSpeed;
        }

        rb.linearVelocity = new Vector3(moveVelocity.x, rb.linearVelocity.y, moveVelocity.z);//new Vector3(movement.x, rb.linearVelocity.y, movement.y) * moveSpeed;
    }
}
