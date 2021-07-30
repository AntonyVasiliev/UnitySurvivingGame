using UnityEngine;

[RequireComponent(typeof(Transform))]

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private Transform _playerBody;
    private float _mouseSensivity = 100f;
    private float _xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        bool isMenu = _pauseMenu.GetComponent<InGameMenu>().IsMenuActive();
        if (!isMenu) {
            float mouseY = Input.GetAxis("Mouse Y") * _mouseSensivity * Time.deltaTime;
            float mouseX = Input.GetAxis("Mouse X") * _mouseSensivity * Time.deltaTime;

            MoveCamera(mouseY);
            RotatePlayer(mouseX);
        }
    }

    //moves camera using "Mouse Y" axis
    private void MoveCamera(float value)
    {
        _xRotation -= value;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 90f, 0f);
    }

    //rotate player using "Mouse X" axis
    private void RotatePlayer(float value)
    {
        _playerBody.Rotate(Vector3.up * value);
    }

}
