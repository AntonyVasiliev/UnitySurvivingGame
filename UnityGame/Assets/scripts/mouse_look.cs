using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_look : MonoBehaviour
{
    public float mouse_sensivity = 100f;
    public Transform playerbody;
    float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouse_sensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouse_sensivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 90f, 0f);

        playerbody.Rotate(Vector3.up * mouseX);
    }
}
