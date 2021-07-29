using UnityEngine;

[RequireComponent(typeof(Transform))]

public class CameraMovement : MonoBehaviour
{
    public GameObject pauseMenu;
    [SerializeField] private Transform playerBody;
    private float mouseSensivity = 100f;
    private float xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        bool isMenu = pauseMenu.GetComponent<InGameMenu>().IsMenuActive();
        if (!isMenu) {
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;
            float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;

            MoveCamera(mouseY);
            RotatePlayer(mouseX);
        }
    }

    //moves camera using "Mouse Y" axis
    private void MoveCamera(float value)
    {
        xRotation -= value;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 90f, 0f);
    }

    //rotate player using "Mouse X" axis
    private void RotatePlayer(float value)
    {
        playerBody.Rotate(Vector3.up * value);
    }

}
