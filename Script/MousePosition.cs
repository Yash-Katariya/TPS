using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public Transform playerBody;
    public float sensitivity = 150f;
    public float smoothTime = 0.05f;

    private float xRotation = 0f;
    private Vector2 currentMouseDelta;
    private Vector2 currentMouseDeltaVelocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Read mouse input
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(
            currentMouseDelta,
            targetMouseDelta,
            ref currentMouseDeltaVelocity,
            smoothTime
        );

        // Rotate camera up/down only (vertical)
        xRotation -= currentMouseDelta.y * sensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate player left/right (horizontal)
        playerBody.Rotate(Vector3.up * currentMouseDelta.x * sensitivity * Time.deltaTime);
    }
}